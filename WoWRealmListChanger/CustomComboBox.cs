﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class CustomComboBox : ComboBox
{
    private const int WM_PAINT = 0xF;
    private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_PAINT)
        {
            using (var g = Graphics.FromHwnd(Handle))
            {
                // Uncomment this if you don't want the "highlight border".
                /*
                using (var p = new Pen(this.BorderColor, 1))
                {
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                }*/
                using (var p = new Pen(this.BorderColor, 3))
                {
                    g.DrawRectangle(p, 1, 1, Width - buttonWidth - 3, Height - 3);
                }
            }
        }
    }

    public CustomComboBox()
    {
        BorderColor = Color.DimGray;
    }

    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "DimGray")]
    public Color BorderColor { get; set; }
}