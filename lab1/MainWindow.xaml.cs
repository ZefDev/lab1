using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static SolidColorBrush brush = new SolidColorBrush(Colors.BlueViolet);//Сюда пихаем
        public static SolidColorBrush background = new SolidColorBrush(Colors.White);

        public static int StrokeThickness = 2;//Толщина линии


        int Instruments = 0;
        Boolean isDrawing = false;
       Point lineStartPoint;
       
        List<Point> listPoints = new List<Point>();
                           

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (isDrawing)
            {
                switch (Instruments)
                {
                    case 0:
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            Line l = new Line();
                            l.X1 = lineStartPoint.X;
                            l.Y1 = lineStartPoint.Y;
                            l.X2 = lineEnd.X;
                            l.Y2 = lineEnd.Y;
                            l.Stroke = brush;
                            l.StrokeThickness = StrokeThickness;
                            myCanvas.Children.Add(l);
                            lineStartPoint = lineEnd;
                        }
                        break;
                    case 1:
                        {

                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void Canvas_MouseUP(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                switch (Instruments)
                {
                    case 1:
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            Line l = new Line();
                            l.X1 = lineStartPoint.X;
                            l.Y1 = lineStartPoint.Y;
                            l.X2 = lineEnd.X;
                            l.Y2 = lineEnd.Y;
                            l.Stroke = brush;
                            l.StrokeThickness = StrokeThickness;
                            myCanvas.Children.Add(l);
                            lineStartPoint = lineEnd;
                        }
                        break;
                    case 3:
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            Rectangle l = new Rectangle();
                            Point hz = new Point();
                            if(lineEnd.X< lineStartPoint.X)
                            {
                                hz.X = lineEnd.X;
                            }
                            else
                            {
                                hz.X = lineStartPoint.X;
                            }
                            if (lineEnd.Y < lineStartPoint.Y)
                            {
                                hz.Y = lineEnd.Y;
                            }
                            else
                            {
                                hz.Y = lineStartPoint.Y;
                            }
                            l.Width = Math.Abs(lineEnd.X - lineStartPoint.X);
                            l.Height = Math.Abs(lineEnd.Y - lineStartPoint.Y);

                            l.Stroke = brush;
                            l.StrokeThickness = StrokeThickness;
                            l.Fill = background;
                            Canvas.SetTop(l, hz.Y);
                            Canvas.SetLeft(l, hz.X);

                            myCanvas.Children.Add(l);
                            lineStartPoint = lineEnd;
                        }
                        break;
                    case 4:
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            Ellipse l = new Ellipse();
                            Point hz = new Point();
                            if (lineEnd.X < lineStartPoint.X)
                            {
                                hz.X = lineEnd.X;
                            }
                            else
                            {
                                hz.X = lineStartPoint.X;
                            }
                            if (lineEnd.Y < lineStartPoint.Y)
                            {
                                hz.Y = lineEnd.Y;
                            }
                            else
                            {
                                hz.Y = lineStartPoint.Y;
                            }
                            l.Width = Math.Abs(lineEnd.X - lineStartPoint.X);
                            l.Height = Math.Abs(lineEnd.Y - lineStartPoint.Y);

                            l.Stroke = brush;
                            l.Fill = background;
                            l.StrokeThickness = StrokeThickness;
                            Canvas.SetTop(l, hz.Y);
                            Canvas.SetLeft(l, hz.X);

                            myCanvas.Children.Add(l);
                            lineStartPoint = lineEnd;
                        }
                        break;
                    case 6:
                        {
                            Point point = new Point();
                            point = e.GetPosition(myCanvas);
                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = textBox.Text;
                            
                            Canvas.SetLeft(textBlock, point.X);
                            Canvas.SetTop(textBlock, point.Y);
                            myCanvas.Children.Add(textBlock);
                        }
                        break;
                    default:
                        break;
                }
            }
            isDrawing = false;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (Instruments)
            {
                case 2:
                    {
                        if (e.RightButton == MouseButtonState.Pressed)
                        {
                            Polyline vertArr = new Polyline();
                            vertArr.Points = new PointCollection();
                            for (int i = 0; i < listPoints.Count; i++)
                            {
                                vertArr.Points.Add(listPoints[i]);
                            }

                            vertArr.Stroke = brush;
                            vertArr.StrokeThickness = StrokeThickness;
                            myCanvas.Children.Add(vertArr);
                            listPoints.Clear();
                        }
                        else
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            listPoints.Add(e.GetPosition(myCanvas));
                        }

                    }
                    break;
                case 5:
                    {
                        if (e.RightButton == MouseButtonState.Pressed)
                        {
                            Polygon vertArr = new Polygon();
                            vertArr.Points = new PointCollection();
                            for (int i = 0; i < listPoints.Count; i++)
                            {
                                vertArr.Points.Add(listPoints[i]);
                            }

                            vertArr.Stroke = brush;
                            vertArr.Fill = background;
                            vertArr.StrokeThickness = StrokeThickness;
                            myCanvas.Children.Add(vertArr);
                            listPoints.Clear();
                        }
                        else
                        {
                            Point lineEnd = e.GetPosition(myCanvas);
                            listPoints.Add(e.GetPosition(myCanvas));
                        }

                    }
                    break;
                default:
                    break;
            }
            isDrawing = true;
            lineStartPoint = e.GetPosition(myCanvas);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 1;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 3;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 4;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (Instruments != 2)
            {
                Instruments = 2;
                listPoints.Clear();
            }
            
        }

        private void button3_Copy_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 5;
            listPoints.Clear();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Instruments = 6;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color drawingColor = colorDialog.Color;
                brush = new SolidColorBrush(Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color drawingColor = colorDialog.Color;
                background = new SolidColorBrush(Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));

            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 passwordWindow = new Window1();

            if (passwordWindow.ShowDialog() == true)
            {
               
            }
            
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int f = comboboxTh.SelectedIndex;

            string text = comboboxTh.Items[f].ToString();

            StrokeThickness = f;
           
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
    

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)myCanvas.RenderSize.Width,
    (int)myCanvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(myCanvas);

            var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)myCanvas.RenderSize.Width, (int)myCanvas.RenderSize.Height));
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем 
            using (var fs = System.IO.File.OpenWrite(filename))
            {
                pngEncoder.Save(fs);
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            //Metafile mf2 = (Metafile)Metafile.FromFile(filename);
            BitmapImage theImage = new BitmapImage(new Uri(filename));
            
            ImageBrush myImageBrush = new ImageBrush(theImage);
            myCanvas.Background = myImageBrush;
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
        }
        private Metafile MakeMetafile(float width, float height,
    string filename,System.Drawing.Bitmap bm)
        {
                using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bm))
                {
                    System.Drawing.RectangleF bounds =
                        new System.Drawing.RectangleF(0, 0, width, height);

                    Metafile mf = null;
                        if ((filename != null) && (filename.Length > 0))
                            mf = new Metafile(@filename, gr.GetHdc(),
                                bounds, MetafileFrameUnit.Pixel);
                        else
                            mf = new Metafile(gr.GetHdc(), bounds,
                                MetafileFrameUnit.Pixel);

                    gr.ReleaseHdc();
                    return mf;
                }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog prnt = new System.Windows.Controls.PrintDialog();

            if (prnt.ShowDialog() == true)
            {
                prnt.PrintVisual(myCanvas, "Printing Canvas");
            }
            this.Close();
        }
    }
}
