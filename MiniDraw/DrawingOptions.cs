using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MiniDraw
{
    public partial class DrawingOptions : Form
    {
        private Dictionary<RadioButton, DashStyle> buttonToStyle;
        private Color lastColor;
        public Pen pen { get; set; }
        private ColorDialog colorDialog;
        public DrawingOptions()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2);
            colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;

            lastColor = Color.Black;
            disableListCheckBox_CheckedChanged(disableListCheckBox, null);

            buttonToStyle = new Dictionary<RadioButton, DashStyle>()
            {
                { solidRadioButton, DashStyle.Solid },
                { dashedRadioButton, DashStyle.Dash },
                { dottedRadioButton, DashStyle.Dot },
                { dashDotRadioButton, DashStyle.DashDot }
            };
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            lastColor = colorDialog.Color;
        }

        private void addCustomLineType(Pen pen)
        {
            customLineTypes.Items.Add($"{pen.DashStyle} -- {pen.Width} -- {pen.Color.ToArgb()}");
        }

        private void disableListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customLineTypes.Enabled = !disableListCheckBox.Checked;
            customLineTypes.BackColor = customLineTypes.Enabled ? Color.White : Color.LightGray;
            customLineTypes.ClearSelected();
        }

        private bool applyPreviousCustomLineType()
        {
            if (customLineTypes.SelectedIndex == -1) return false;
            string[] serilizedLineTypes = (customLineTypes.SelectedItem as string).Split(new string[] { " -- " }, StringSplitOptions.None);
            pen.DashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), serilizedLineTypes[0]);
            pen.Color = Color.FromArgb(int.Parse(serilizedLineTypes[2]));
            pen.Width = float.Parse(serilizedLineTypes[1]);
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (disableListCheckBox.Checked || !applyPreviousCustomLineType())
            {
                Pen prevPen = pen.Clone() as Pen;
                pen.DashStyle = buttonToStyle[lineTypeGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)];
                pen.Width = (float)lineWidthNumericUpDown.Value;
                pen.Color = lastColor;
                if (prevPen.Color.ToArgb() != pen.Color.ToArgb() || prevPen.DashStyle != pen.DashStyle || prevPen.Width != pen.Width)
                    addCustomLineType(pen);
            }
            Close();
        }       
    }
}
