using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace NowAndNext
{
    internal class Clock
    {
        private static readonly Brush FACE_BRUSH = Brushes.White;
        private static readonly Brush BORDER_BRUSH = Brushes.Black;

        internal void Draw()
        {
            throw new NotImplementedException();
        }

        private static readonly List<Brush> SWEEP_BRUSHES = new() { Brushes.LightCoral, Brushes.LightSteelBlue, Brushes.LightPink, Brushes.MediumPurple };

        private static readonly int BORDER_PIXELS = 4;
        private static readonly Pen BORDER_PEN = new(BORDER_BRUSH, BORDER_PIXELS);
        private static readonly Pen TICK_PEN_THICK = new(Color.Black, 4);
        private static readonly Pen TICK_PEN_THIN = new(Color.Black);

        private static readonly float FACE_ANGLE_TOP = -90.0f;
        private static readonly float BIG_TICK_START_RADIUS = 0.8f;
        private static readonly float SMALL_TICK_START_RADIUS = 0.85f;
        private static readonly float TICK_END_RADIUS = 0.9f;

        private readonly List<DateTime> eventTimes = new();
        private readonly Font font;

        public Clock(Font font)
        {
            this.font = font;
        }

        public void SetEventTimes(IEnumerable<DateTime> events)
        {
            if (events.Any())
            {
                foreach (DateTime eventTime in events)
                {
                    eventTimes.RemoveAll(x => !events.Contains(x));
                    if (!eventTimes.Contains(eventTime))
                    {
                        eventTimes.Add(eventTime);
                    }
                }
            }
            else
            {
                eventTimes.Clear();
            }
        }

        private static TimeSpan GetTimeUntil(DateTime dateTime)
        {
            return dateTime - DateTime.Now;
        }

        private static string GetFormattedTimeUntil(DateTime dateTime)
        {
            TimeSpan time = GetTimeUntil(dateTime);
            return time.ToString(@"m\:ss");
        }

        private void DrawTick(Graphics graphics, Pen p, double angle, float inner_r, float outer_r)
        {
            float size = Math.Min(graphics.ClipBounds.Width, graphics.ClipBounds.Height);

            float outer_x_factor = outer_r * size / 2;
            float outer_y_factor = outer_r * size / 2;
            float inner_x_factor = inner_r * size / 2;
            float inner_y_factor = inner_r * size / 2;

            float cos_angle = (float)Math.Cos(angle);
            float sin_angle = (float)Math.Sin(angle);
            PointF outer_pt = new(
                outer_x_factor * cos_angle,
                outer_y_factor * sin_angle);
            PointF inner_pt = new(
                inner_x_factor * cos_angle,
                inner_y_factor * sin_angle);
            graphics.DrawLine(p, inner_pt, outer_pt);
        }
        private static float GetSweepAngleFromTime(DateTime dateTime)
        {
            return (float)(GetTimeUntil(dateTime).TotalSeconds / 10.0f);
        }

        private static IEnumerable<Brush> GetSweepBrushes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return SWEEP_BRUSHES[i % SWEEP_BRUSHES.Count];
            }
        }

        public void Draw(Graphics graphics)
        {
            int size = (int)Math.Min(graphics.ClipBounds.Width, graphics.ClipBounds.Height);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Put origin in centre of client area
            graphics.TranslateTransform(
                size / 2,
                size / 2);

            // We're going to draw arcs and pies in a common rectangle, which is the client rectangle minus some padding:
            Rectangle padRectangle = new(
                (-size / 2) + 4, (-size / 2) + 4,
                size - 8, size - 8);

            if (padRectangle.Width <= 0 || padRectangle.Height <= 0)
                return;

            // Now the drawing, in z-order

            // Clock Face
            graphics.FillEllipse(FACE_BRUSH, padRectangle);

            // Draw the sweep
            foreach ((Brush brush, DateTime entry) in GetSweepBrushes(eventTimes.Count).Zip(eventTimes).Reverse())
            {
                DrawSweep(graphics, brush, padRectangle, entry);
            }

            // Bezel and dot
            graphics.DrawEllipse(BORDER_PEN, padRectangle);
            graphics.FillEllipse(BORDER_BRUSH, new Rectangle(-BORDER_PIXELS, -BORDER_PIXELS, 2 * BORDER_PIXELS, 2 * BORDER_PIXELS));

            // Draw the tick marks.
            for (int minute = 1; minute <= 60; minute++)
            {
                double angle = Math.PI * minute / 30.0;
                if (minute % 5 == 0)
                {
                    DrawTick(graphics, TICK_PEN_THICK, angle, BIG_TICK_START_RADIUS, TICK_END_RADIUS);
                }
                else
                {
                    DrawTick(graphics, TICK_PEN_THIN, angle, SMALL_TICK_START_RADIUS, TICK_END_RADIUS);
                }
            }

            if (eventTimes.Any())
                DrawTextCentred(graphics, new Point(0, (size / 6)), GetFormattedTimeUntil(eventTimes.First()), font, Brushes.Black);
        }

        private static void DrawSweep(Graphics graphics, Brush brush, Rectangle rectangle, DateTime dateTime)
        {
            graphics.FillPie(brush, rectangle, FACE_ANGLE_TOP, GetSweepAngleFromTime(dateTime));
        }

        private static void DrawTextCentred(Graphics graphics, Point where, string text, Font font, Brush brush)
        {
            SizeF textBoundingBox = graphics.MeasureString(text, font);
            Point textPoints = new(
                where.X - (int)(textBoundingBox.Width / 2),
                where.Y - (int)(textBoundingBox.Height / 2));
            graphics.DrawString(text, font, brush, textPoints);
        }
    }
}
