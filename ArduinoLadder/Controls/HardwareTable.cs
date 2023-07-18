using ArduinoLadder.Ladder;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Extensions;
using Devinno.Forms.Themes;
using Devinno.Forms.Utils;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = ArduinoLadder.Tools.LangTool;

namespace ArduinoLadder.Controls
{
    public class HardwareTable : DvControl
    {
        #region Const
        private int ItemHeight = 20;
        #endregion

        #region Member Variable
        private Scroll scrollOUT = new Scroll();
        private Scroll scrollIN = new Scroll();
        private Scroll scrollAD = new Scroll();
        private Scroll scrollDA = new Scroll();

        private List<HardwareInfo> ItemsOUT = new List<HardwareInfo>();
        private List<HardwareInfo> ItemsIN = new List<HardwareInfo>();
        private List<HardwareInfo> ItemsAD = new List<HardwareInfo>();
        private List<HardwareInfo> ItemsDA = new List<HardwareInfo>();
        #endregion

        #region Constructor
        public HardwareTable()
        {
            scrollOUT = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollOUT.GetScrollTotal = () => ItemsOUT.Count * ItemHeight;
            scrollOUT.GetScrollTick = () => ItemHeight;
            scrollOUT.GetScrollView = () => ((this.Height - 10) / 2) - 48;
            scrollOUT.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollOUT.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollIN = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollIN.GetScrollTotal = () => ItemsIN.Count * ItemHeight;
            scrollIN.GetScrollTick = () => ItemHeight;
            scrollIN.GetScrollView = () => ((this.Height - 10) / 2) - 48;
            scrollIN.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollIN.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollAD = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollAD.GetScrollTotal = () => ItemsAD.Count * ItemHeight;
            scrollAD.GetScrollTick = () => ItemHeight;
            scrollAD.GetScrollView = () => ((this.Height - 10) / 2) - 48;
            scrollAD.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollAD.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };

            scrollDA = new Scroll() { Direction = ScrollDirection.Vertical, TouchMode = true };
            scrollDA.GetScrollTotal = () => ItemsDA.Count * ItemHeight;
            scrollDA.GetScrollTick = () => ItemHeight;
            scrollDA.GetScrollView = () => ((this.Height - 10) / 2) - 48;
            scrollDA.ScrollChanged += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
            scrollDA.ScrollEnded += (o, s) => { if (Created && !IsDisposed && Visible) this.Invoke(new Action(() => Invalidate())); };
        }
        #endregion

        #region Override
        #region OnThemeDraw
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            #region Var
            var ScrollBorderColor = Theme.GetBorderColor(Theme.ScrollBarColor, BackColor);
            var rndBox = RoundType.L;
            var rndScroll = RoundType.R;
            #endregion
            #region Init
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var p = new Pen(Color.Black);
            var br = new SolidBrush(Color.Black);
            var ft = new Font("나눔고딕", 8);
            #endregion

            Areas((rtContent, rts) =>
            {
                var m = new string[] { "OUT", "IN", "AD", "DA" };
                var scrolls = new Scroll[] { scrollOUT, scrollIN, scrollAD, scrollDA };
                var lsItems = new List<HardwareInfo>[] { ItemsOUT, ItemsIN, ItemsAD, ItemsDA };

                for (int i = 0; i < 4; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];
                    var items = lsItems[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        #region Background
                        {
                            br.Color = Color.FromArgb(30, 30, 30);

                            e.Graphics.FillRoundRectangleT(br, rtTitle, 5);
                            e.Graphics.FillRoundRectangleRB(br, rtScroll, 5);
                            e.Graphics.FillRectangle(br, rtCol);

                            e.Graphics.DrawLine(Pens.Black, rtTitle.Left, rtTitle.Bottom, rtTitle.Right, rtTitle.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtTitle.Left, rtCol1.Bottom, rtTitle.Right, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtCol2.Left, rtCol1.Top, rtCol2.Left, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtSC.Left, rtCol1.Top, rtSC.Left, rtCol1.Bottom);
                            e.Graphics.DrawLine(Pens.Black, rtScroll.Left, rtScroll.Top, rtScroll.Left, rtScroll.Bottom);

                            Theme.DrawText(e.Graphics, m[i], Font, Color.FromArgb(200, 200, 200), rtTitle);

                            Theme.DrawText(e.Graphics, LM.PinNumber, Font, Color.FromArgb(200, 200, 200), rtCol1);
                            Theme.DrawText(e.Graphics, LM.Address, Font, Color.FromArgb(200, 200, 200), rtCol2);
                        }
                        #endregion

                        #region Rows
                        e.Graphics.SetClip(new RectangleF(rtRows.X, rtRows.Y + 1, rtRows.Width, rtRows.Height - 1));
                        loop(rtRows, (idx, rtr, itm) =>
                        {
                            var rtAddr = new RectangleF(rtCol1.X, rtr.Y, rtCol1.Width, rtr.Height);
                            var rtSym = new RectangleF(rtCol2.X, rtr.Y, rtCol2.Width, rtr.Height);

                            Theme.DrawText(e.Graphics, itm.Pin.ToString(), ft, Color.White, rtAddr);
                            Theme.DrawText(e.Graphics, itm.Address, ft, Color.White, rtSym);

                        }, scroll, items);
                        e.Graphics.ResetClip();
                        #endregion

                        #region Scroll
                        {
                            Theme.DrawBox(e.Graphics, rtScroll, Theme.ScrollBarColor, ScrollBorderColor, rndScroll, Box.FlatBox(true));

                            e.Graphics.SetClip(Util.FromRect(rtScroll.Left, rtScroll.Top + 0, rtScroll.Width, rtScroll.Height - 0));

                            var cCur = Theme.ScrollCursorOffColor;
                            if (scroll.IsScrolling || scroll.IsTouchMoving) cCur = Theme.ScrollCursorOnColor;

                            var rtcur = scroll.GetScrollCursorRect(rtScroll);
                            if (rtcur.HasValue) Theme.DrawBox(e.Graphics, Util.INT(rtcur.Value), cCur, ScrollBorderColor, RoundType.All, Box.FlatBox(true));

                            e.Graphics.ResetClip();
                        }
                        #endregion

                    });

                    e.Graphics.DrawRoundRectangle(Pens.Black, Util.INT(rt), 5);
                }

            });

            #region Dispose
            br.Dispose();
            p.Dispose();
            ft.Dispose();
            #endregion
            base.OnThemeDraw(e, Theme);
        }
        #endregion
        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollOUT, scrollIN, scrollAD, scrollDA };

                for (int i = 0; i < 4; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseDown(x, y, rtScroll);
                    });
                }

            });

            Invalidate();
            base.OnMouseDown(e);
        }
        #endregion
        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollOUT, scrollIN, scrollAD, scrollDA };

                for (int i = 0; i < 4; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseUp(x, y);
                    });
                }

            });

            Invalidate();
            base.OnMouseUp(e);
        }
        #endregion
        #region OnMouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            bool bInv = false;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollOUT, scrollIN, scrollAD, scrollDA };

                for (int i = 0; i < 4; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        scroll.MouseMove(x, y, rtScroll);
                    });

                    if (scroll.IsScrolling || scroll.IsTouchMoving || scroll.IsTouchScrolling) bInv |= true;
                }

            });

            if (bInv) Invalidate();
            base.OnMouseMove(e);
        }
        #endregion
        #region OnMouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            bool bInv = false;

            Areas((rtContent, rts) =>
            {
                var scrolls = new Scroll[] { scrollOUT, scrollIN, scrollAD, scrollDA };

                for (int i = 0; i < 4; i++)
                {
                    var rt = rts[i];
                    var scroll = scrolls[i];

                    AreasTBL(rt, (rtTitle, rtCol, rtCol1, rtCol2, rtSC, rtRows, rtScroll) =>
                    {
                        if (CollisionTool.Check(rt, e.Location))
                        {
                            scroll.MouseWheel(e.Delta, rtScroll);
                            bInv |= true;
                        }
                    });
                }

            });

            if (bInv) Invalidate();
            base.OnMouseWheel(e);
        }
        #endregion
        #endregion

        #region Method
        #region Areas
        void Areas(Action<RectangleF, RectangleF[]> act)
        {
            var rtContent = GetContentBounds();
            var lsc = new List<SizeInfo>();
            var lsr = new List<SizeInfo>();

            lsc.Add(new SizeInfo(DvSizeMode.Percent, 50));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 50));

            lsr.Add(new SizeInfo(DvSizeMode.Percent, 50));
            lsr.Add(new SizeInfo(DvSizeMode.Pixel, 10));
            lsr.Add(new SizeInfo(DvSizeMode.Percent, 50));

            var rts = Util.DevideSizeVH(rtContent, lsr, lsc);

            act(rtContent, new RectangleF[] { rts[0, 0], rts[0, 2], rts[2, 0], rts[2, 2] });
        }
        #endregion
        #region AreasTBL
        void AreasTBL(RectangleF rt, Action<Rectangle, Rectangle, Rectangle, Rectangle, Rectangle, Rectangle, Rectangle> act)
        {
            var rh = ItemHeight;

            var lsc = new List<SizeInfo>();
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 40));
            lsc.Add(new SizeInfo(DvSizeMode.Percent, 60));
            lsc.Add(new SizeInfo(DvSizeMode.Pixel, 14));
            var rts = Util.DevideSizeH(new RectangleF(rt.X, rt.Y + rh, rt.Width, rh), lsc);

            var rtTitle = new RectangleF(rt.X, rt.Y, rt.Width, rh);
            var rtCol = new RectangleF(rt.X, rt.Y + rh, rt.Width, rh);
            var rtCol1 = rts[0];
            var rtCol2 = rts[1];
            var rtSC = rts[2];
            var rtRows = new RectangleF(rt.X, rtCol1.Bottom, rt.Width, rt.Height - (rh * 2));
            var rtScroll = new RectangleF(rtSC.Left, rtCol1.Bottom, rtSC.Width, rt.Height - (rh * 2));

            act(Util.INT(rtTitle),
                Util.INT(rtCol), Util.INT(rtCol1), Util.INT(rtCol2), Util.INT(rtSC),
                Util.INT(rtRows), Util.INT(rtScroll));
        }
        #endregion

        #region SetItems
        public void SetItems(List<HardwareInfo> Items)
        {
            ItemsOUT.Clear();
            ItemsIN.Clear();
            ItemsAD.Clear();
            ItemsDA.Clear();

            var lso = Items.Where(x => x.Mode == "OUT").ToList();
            var lsi = Items.Where(x => x.Mode == "IN").ToList();
            var lsa = Items.Where(x => x.Mode == "AD").ToList();
            var lsd = Items.Where(x => x.Mode == "DA").ToList();

            ItemsOUT.AddRange(lso.OrderBy(x => x.Pin));
            ItemsIN.AddRange(lsi.OrderBy(x => x.Pin));
            ItemsAD.AddRange(lsa.OrderBy(x => x.Pin));
            ItemsDA.AddRange(lsd.OrderBy(x => x.Pin));

            Invalidate();
        }
        #endregion

        #region loop
        private void loop(RectangleF rtBox, Action<int, RectangleF, HardwareInfo> act, Scroll scroll, List<HardwareInfo> Items)
        {
            if (!IsDisposed)
            {
                var sc = scroll.ScrollPosition;
                var spos = Convert.ToInt32(scroll.ScrollPositionWithOffset);

                var si = Convert.ToInt32(Math.Floor((double)(sc - scroll.TouchOffset) / (double)ItemHeight));
                var cnt = Convert.ToInt32(Math.Ceiling((double)(rtBox.Height - Math.Min(0, scroll.TouchOffset)) / (double)ItemHeight));
                var ei = si + cnt;

                using (var g = CreateGraphics())
                {
                    for (int i = Math.Max(0, si); i < ei + 1 && i < Items.Count; i++)
                    {
                        var itm = Items[i];
                        var rt = Util.FromRect(rtBox.Left, spos + rtBox.Top + (ItemHeight * i), rtBox.Width, ItemHeight);
                        if (CollisionTool.Check(Util.FromRect(rt.Left + 1, rt.Top + 1, rt.Width - 2, rt.Height - 2), rtBox)) act(i, rt, itm);
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
