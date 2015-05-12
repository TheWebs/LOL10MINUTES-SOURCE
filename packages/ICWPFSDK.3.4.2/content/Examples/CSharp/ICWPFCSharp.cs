using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace ICWPFExample
{
    public class CSharpExample
    {

        /// <summary>
        /// Initialize example.
        /// </summary>
        public void Initialize()
        {
            //Creates a new windows form.
            System.Windows.Window m_Form = new System.Windows.Window();
            m_Form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            m_Form.ResizeMode = System.Windows.ResizeMode.NoResize;
            m_Form.Width = 890;
            m_Form.Height = 660;
            //Creates a new ImgEdit control instance.
            ImageComponents.WPF.Imaging.ImgEdit m_ImgEdit = new ImageComponents.WPF.Imaging.ImgEdit();
            m_ImgEdit.BorderBrush = new SolidColorBrush(Colors.Black);
            m_ImgEdit.BorderThickness = new System.Windows.Thickness(1);
            m_ImgEdit.Margin = new System.Windows.Thickness(4);
            m_ImgEdit.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_ImgEdit.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_ImgEdit.Width = 600;
            m_ImgEdit.Height = 610;
            //Create a new grid to the window
            Grid m_Grid = new Grid();
            //Add the grid to the content of the window.
            m_Form.Content = m_Grid;
            //Adds the ImgEdit control instance to the grid.
            m_Grid.Children.Add(m_ImgEdit);
            //Creates a new ImgThumbnails control instance.
            ImageComponents.WPF.Imaging.ImgThumbnails m_ImgThumbnails = new ImageComponents.WPF.Imaging.ImgThumbnails();
            m_ImgThumbnails.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_ImgThumbnails.ImgEditComponent = m_ImgEdit;
            m_ImgThumbnails.BorderBrush = new SolidColorBrush(Colors.Black);
            m_ImgThumbnails.BorderThickness = new System.Windows.Thickness(1);
            m_ImgThumbnails.Margin = new System.Windows.Thickness(610, 4, 0, 4);
            m_ImgThumbnails.Width = 260;
            m_ImgThumbnails.Height = 400;
            //Adds the ImgThumbnails control instance to the grid.
            m_Grid.Children.Add(m_ImgThumbnails);
            //Creates a new ImgScan control instance.
            ImageComponents.WPF.Imaging.ImgScan m_ImgScan = new ImageComponents.WPF.Imaging.ImgScan();
            m_ImgScan.ImgEditComponent = m_ImgEdit;

            #region Open image button

            //######### OPEN IMAGE BUTTON #########
            //Creates a new button.
            System.Windows.Controls.Button m_LoadButton = new System.Windows.Controls.Button();
            m_LoadButton.Width = 100; m_LoadButton.Height = 32;
            m_LoadButton.Content = "Load Image";
            m_LoadButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_LoadButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_LoadButton.Margin = new System.Windows.Thickness(m_Form.Width - 30 - m_LoadButton.Width, m_Form.Height - 50 - m_LoadButton.Height, 0, 0);
            //Adds the button control to the form.
            m_Grid.Children.Add(m_LoadButton);
            //Button click event.
            m_LoadButton.Click += (s, e) =>
                {
                    //Creates and display the open file dialog.
                    OpenFileDialog m_OpenFile = new OpenFileDialog();
                    m_OpenFile.Filter = "Supported Image Files |*.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.gif;*.png;*.cut;*.dds;*.g3;*.hdr;*.ico;*.iff;*.lbm;*.jng;*.koa;*.mng;*.pbm;*.pcd;*.pcx;*.pgm;*.ppm;*.psd;*.ras;*.sgi;*.tga;*.targa;*.wbmp;*.xbm;*.xpm;*.wmf;*.pdf;*.xps";
                    if (m_OpenFile.ShowDialog() == true)
                    {
                        //Display the selected image on the control.
                        m_ImgEdit.ImageFilePath = m_OpenFile.FileName;
                        m_ImgEdit.Display();
                        m_ImgEdit.FitTo(ImageComponents.WPF.Imaging.ImgEdit.ICImageFit.BestFit, true);
                    }
                };

            #endregion

            #region Save image button

            //######### SAVE IMAGE BUTTON #########
            //Creates a new button.
            System.Windows.Controls.Button m_SaveButton = new System.Windows.Controls.Button();
            m_SaveButton.Width = 100;
            m_SaveButton.Height = 32;
            m_SaveButton.Content = "Save Image";
            m_SaveButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_SaveButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_SaveButton.Margin = new System.Windows.Thickness(m_Form.Width - 130 - m_SaveButton.Width, m_Form.Height - 50 - m_SaveButton.Height, 0, 0);
            //Adds the button control to the form.
            m_Grid.Children.Add(m_SaveButton);
            //Button click event.
            m_SaveButton.Click += (s, e) =>
            {
                //Creates and display the open file dialog.
                SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
                m_SaveFileDialog.Filter = "Microsoft Windows Bitmap (*bmp)|*.bmp|JPEG File (*.jpg)|*.jpg|Tagged Image File Default Compression (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File Uncompressed (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File LZW (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File CCITT3 (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File CCITT4 (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File RLE (*.tif;*.tiff)|*.tif;*.tiff|Graphics Interchange Format (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Portable Document Format (*.pdf)|*.pdf";
                if (m_SaveFileDialog.ShowDialog() == true)
                {
                    switch (m_SaveFileDialog.FilterIndex)
                    {
                        case 1:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.BMP;
                            break;
                        case 2:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.JPEG;
                            break;
                        case 3:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.DEFAULT;
                            break;
                        case 4:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.NONE;
                            break;
                        case 5:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.LZW;
                            break;
                        case 6:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.CCITT3;
                            break;
                        case 7:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.CCITT4;
                            break;
                        case 8:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF;
                            m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.RLE;
                            break;
                        case 9:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.GIF;
                            break;
                        case 10:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.PNG;
                            break;
                        case 11:
                            m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.PDF;
                            m_ImgEdit.SavePDFAsSearchable = true;
                            break;
                    }
                    m_ImgEdit.SaveOutputType = ImageComponents.WPF.Imaging.ImgEdit.ICImageSaveOutputType.FileSystem;
                    m_ImgEdit.SaveImageAs(m_SaveFileDialog.FileName);
                }
            };

            #endregion

            #region Rotate Left Button

            //######### ROTATE LEFT BUTTON #########
            //Creates a new button.
            System.Windows.Controls.Button m_RotateLeftButton = new System.Windows.Controls.Button();
            m_RotateLeftButton.Width = 100;
            m_RotateLeftButton.Height = 32;
            m_RotateLeftButton.Content = "Rotate Left";
            m_RotateLeftButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_RotateLeftButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_RotateLeftButton.Margin = new System.Windows.Thickness(m_Form.Width - 130 - m_RotateLeftButton.Width, m_Form.Height - 82 - m_RotateLeftButton.Height, 0, 0);
            //Adds the button control to the form.
            m_Grid.Children.Add(m_RotateLeftButton);
            //Button click event.
            m_RotateLeftButton.Click += (s, e) =>
            {
                m_ImgEdit.RotateLeft();
            };

            #endregion

            #region Rotate right button

            //######### ROTATE RIGHT BUTTON #########
            //Creates a new button.
            System.Windows.Controls.Button m_RotateRightButton = new System.Windows.Controls.Button();
            m_RotateRightButton.Width = 100;
            m_RotateRightButton.Height = 32;
            m_RotateRightButton.Content = "Rotate Right";
            m_RotateRightButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_RotateRightButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_RotateRightButton.Margin = new System.Windows.Thickness(m_Form.Width - 30 - m_RotateRightButton.Width, m_Form.Height - 82 - m_RotateRightButton.Height, 0, 0);
            //Adds the button control to the form.
            m_Grid.Children.Add(m_RotateRightButton);
            //Button click event.
            m_RotateRightButton.Click += (s, e) =>
            {
                m_ImgEdit.RotateRight();
            };

            #endregion

            #region Scan button

            //######### SCAN IMAGE BUTTON #########
            //Creates a new button.
            System.Windows.Controls.Button m_ScanImageButton = new System.Windows.Controls.Button();
            m_ScanImageButton.Width = 100;
            m_ScanImageButton.Height = 32;
            m_ScanImageButton.Content = "Scan Image";
            m_ScanImageButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_ScanImageButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            m_ScanImageButton.Margin = new System.Windows.Thickness(m_Form.Width - 30 - m_ScanImageButton.Width, m_Form.Height - 114 - m_ScanImageButton.Height, 0, 0);
            //Adds the button control to the form.
            m_Grid.Children.Add(m_ScanImageButton);
            //Button click event.
            m_ScanImageButton.Click += (s, e) =>
            {
                m_ImgScan.ImageAcquireMode = ImageComponents.WPF.Imaging.ImgScan.ICImageAcquireMode.Single;
                m_ImgScan.SaveImageFormat = ImageComponents.WPF.Imaging.ImgScan.ICImageOutputFormat.TIFF;
                m_ImgScan.SaveImageCompression = ImageComponents.WPF.Imaging.ImgScan.ICImageCompression.CCITT4;
                m_ImgScan.DeviceTransferMode = ImageComponents.WPF.Imaging.ImgScan.ICImageTransferMode.Memory;
                m_ImgScan.SaveFileNamePrefix = "IMG";
                m_ImgScan.ImageFileDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "\\";
                m_ImgScan.RemoveBlankPages = false;
                m_ImgScan.ImagePageSeparation = ImageComponents.WPF.Imaging.ImgScan.ICImagePageSeparationType.None;
                m_ImgScan.ShowScannerUI = true;
                m_ImgScan.EnableMessageLoop = false;
                if (String.IsNullOrEmpty(m_ImgScan.ActiveSourceName))
                {
                    if (!m_ImgScan.SelectSource()) { return; };
                }
                m_ImgScan.Acquire();
            };

            #endregion
            //Display the new created form.
            m_Form.Show();
        }

    }
}
