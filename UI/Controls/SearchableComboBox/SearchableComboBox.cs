using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VRMS.UI.Controls
{
    public partial class SearchableComboBox : UserControl
    {
        // =========================
        // EVENTS
        // =========================
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;
        public event EventHandler<SearchRequestedEventArgs> SearchRequested;

        // =========================
        // STATE
        // =========================
        private readonly List<object> _items = new();
        private object _selectedItem;

        private readonly System.Windows.Forms.Timer _searchTimer;
        private const int DebounceMs = 300;

        private bool _hasUserTyped;

        private string _displayMember = string.Empty;

        // =========================
        // CONSTRUCTOR
        // =========================
        public SearchableComboBox()
        {
            InitializeComponent();

            _searchTimer = new System.Windows.Forms.Timer
            {
                Interval = DebounceMs
            };
            _searchTimer.Tick += SearchTimer_Tick;

            WireEvents();
            ApplyPlaceholder();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;

            lstResults.MouseClick += (_, __) => SelectCurrentItem();
            lstResults.DoubleClick += (_, __) => SelectCurrentItem();
            lstResults.KeyDown += LstResults_KeyDown;

            btnClear.Click += (_, __) => Clear();
        }

        // =========================
        // DESIGNER-SAFE PROPERTIES
        // =========================

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object> Items => _items;

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayMember
        {
            get => _displayMember;
            set => _displayMember = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText { get; set; } = "Type to search...";

        // =========================
        // PUBLIC API
        // =========================
        public void SetItems(IEnumerable<object> items)
        {
            _items.Clear();
            _items.AddRange(items);

            lstResults.BeginUpdate();
            lstResults.Items.Clear();

            foreach (var item in _items)
            {
                lstResults.Items.Add(GetDisplayText(item));
            }

            lstResults.EndUpdate();
            lstResults.Visible = lstResults.Items.Count > 0;
        }

        public void Clear()
        {
            _selectedItem = null;
            _items.Clear();
            lstResults.Items.Clear();
            lstResults.Visible = false;

            _hasUserTyped = false;
            ApplyPlaceholder();
        }

        // =========================
        // TEXT / PLACEHOLDER LOGIC
        // =========================
        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (!_hasUserTyped)
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (!_hasUserTyped)
                ApplyPlaceholder();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_hasUserTyped)
            {
                _hasUserTyped = true;
                txtSearch.ForeColor = Color.Black;
            }

            if (txtSearch.Text.Length < 2)
            {
                lstResults.Visible = false;
                return;
            }

            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void ApplyPlaceholder()
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
        }

        // =========================
        // SEARCH TIMER
        // =========================
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            SearchRequested?.Invoke(this, new SearchRequestedEventArgs
            {
                SearchText = txtSearch.Text
            });
        }

        // =========================
        // SELECTION
        // =========================
        private void LstResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectCurrentItem();
        }

        private void SelectCurrentItem()
        {
            if (lstResults.SelectedIndex < 0)
                return;

            _selectedItem = _items[lstResults.SelectedIndex];
            txtSearch.Text = GetDisplayText(_selectedItem);
            txtSearch.ForeColor = Color.Black;

            ItemSelected?.Invoke(this, new ItemSelectedEventArgs
            {
                SelectedItem = _selectedItem,
                SelectedText = txtSearch.Text,
                SelectedValue = _selectedItem
            });

            lstResults.Visible = false;
        }

        private string GetDisplayText(object item)
        {
            if (item == null)
                return string.Empty;

            if (!string.IsNullOrEmpty(_displayMember))
            {
                var prop = item.GetType().GetProperty(_displayMember);
                if (prop != null)
                    return prop.GetValue(item)?.ToString() ?? string.Empty;
            }

            return item.ToString();
        }
    }

    // =========================
    // EVENT ARGS
    // =========================
    public class ItemSelectedEventArgs : EventArgs
    {
        public object SelectedItem { get; set; }
        public string SelectedText { get; set; }
        public object SelectedValue { get; set; }
    }

    public class SearchRequestedEventArgs : EventArgs
    {
        public string SearchText { get; set; }
    }
}
