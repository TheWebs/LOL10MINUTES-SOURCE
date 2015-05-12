Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows.Media
Imports Microsoft.Win32

Namespace ICWPFExample
    Public Class VBExample

        Friend WithEvents m_LoadButton As System.Windows.Controls.Button
        Friend WithEvents m_SaveButton As System.Windows.Controls.Button
        Friend WithEvents m_RotateLeftButton As System.Windows.Controls.Button
        Friend WithEvents m_RotateRightButton As System.Windows.Controls.Button
        Friend WithEvents m_ScanImageButton As System.Windows.Controls.Button
        Private m_ImgEdit As ImageComponents.WPF.Imaging.ImgEdit
        Private m_ImgScan As ImageComponents.WPF.Imaging.ImgScan

        Public Sub Initialize()
            'Creates a new windows form.
            Dim m_Form As New System.Windows.Window()
            m_Form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            m_Form.ResizeMode = System.Windows.ResizeMode.NoResize
            m_Form.Width = 890
            m_Form.Height = 660
            'Creates a new ImgEdit control instance.
            m_ImgEdit = New ImageComponents.WPF.Imaging.ImgEdit()
            m_ImgEdit.BorderBrush = New SolidColorBrush(Colors.Black)
            m_ImgEdit.BorderThickness = New System.Windows.Thickness(1)
            m_ImgEdit.Margin = New System.Windows.Thickness(4)
            m_ImgEdit.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_ImgEdit.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_ImgEdit.Width = 600
            m_ImgEdit.Height = 610
            ''Create a new grid to the window
            Dim m_Grid As Grid = New Grid()
            ''Add the grid to the content of the window.
            m_Form.Content = m_Grid
            ''Adds the ImgEdit control instance to the grid.
            m_Grid.Children.Add(m_ImgEdit)
            'Creates a new ImgThumbnails control instance.
            Dim m_ImgThumbnails As New ImageComponents.WPF.Imaging.ImgThumbnails()
            m_ImgThumbnails.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_ImgThumbnails.ImgEditComponent = m_ImgEdit
            m_ImgThumbnails.BorderBrush = New SolidColorBrush(Colors.Black)
            m_ImgThumbnails.BorderThickness = New System.Windows.Thickness(1)
            m_ImgThumbnails.Margin = New System.Windows.Thickness(610, 4, 0, 4)
            m_ImgThumbnails.Width = 260
            m_ImgThumbnails.Height = 400
            'Adds the ImgThumbnails control instance to the grid.
            m_Grid.Children.Add(m_ImgThumbnails)
            'Creates a new ImgScan control instance.
            m_ImgScan = New ImageComponents.WPF.Imaging.ImgScan()
            m_ImgScan.ImgEditComponent = m_ImgEdit

            '######### OPEN IMAGE BUTTON #########
            'Creates a new button.
            m_LoadButton = New System.Windows.Controls.Button()
            m_LoadButton.Width = 100
            m_LoadButton.Height = 32
            m_LoadButton.Content = "Load Image"
            m_LoadButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_LoadButton.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_LoadButton.Margin = New System.Windows.Thickness(m_Form.Width - 30 - m_LoadButton.Width, m_Form.Height - 50 - m_LoadButton.Height, 0, 0)
            'Adds the button control to the form.
            m_Grid.Children.Add(m_LoadButton)

            '######### SAVE IMAGE BUTTON #########
            'Creates a new button.
            m_SaveButton = New System.Windows.Controls.Button()
            m_SaveButton.Width = 100
            m_SaveButton.Height = 32
            m_SaveButton.Content = "Save Image"
            m_SaveButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_SaveButton.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_SaveButton.Margin = New System.Windows.Thickness(m_Form.Width - 130 - m_SaveButton.Width, m_Form.Height - 50 - m_SaveButton.Height, 0, 0)
            'Adds the button control to the form.
            m_Grid.Children.Add(m_SaveButton)

            '######### ROTATE LEFT BUTTON #########
            'Creates a new button.
            m_RotateLeftButton = New System.Windows.Controls.Button()
            m_RotateLeftButton.Width = 100
            m_RotateLeftButton.Height = 32
            m_RotateLeftButton.Content = "Rotate Left"
            m_RotateLeftButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_RotateLeftButton.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_RotateLeftButton.Margin = New System.Windows.Thickness(m_Form.Width - 130 - m_RotateLeftButton.Width, m_Form.Height - 82 - m_RotateLeftButton.Height, 0, 0)
            'Adds the button control to the form.
            m_Grid.Children.Add(m_RotateLeftButton)

            '######### ROTATE RIGHT BUTTON #########
            'Creates a new button.
            m_RotateRightButton = New System.Windows.Controls.Button()
            m_RotateRightButton.Width = 100
            m_RotateRightButton.Height = 32
            m_RotateRightButton.Content = "Rotate Right"
            m_RotateRightButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_RotateRightButton.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_RotateRightButton.Margin = New System.Windows.Thickness(m_Form.Width - 30 - m_RotateRightButton.Width, m_Form.Height - 82 - m_RotateRightButton.Height, 0, 0)
            'Adds the button control to the form.
            m_Grid.Children.Add(m_RotateRightButton)

            '######### SCAN IMAGE BUTTON #########
            'Creates a new button.
            m_ScanImageButton = New System.Windows.Controls.Button()
            m_ScanImageButton.Width = 100
            m_ScanImageButton.Height = 32
            m_ScanImageButton.Content = "Scan Image"
            m_ScanImageButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            m_ScanImageButton.VerticalAlignment = System.Windows.VerticalAlignment.Top
            m_ScanImageButton.Margin = New System.Windows.Thickness(m_Form.Width - 30 - m_ScanImageButton.Width, m_Form.Height - 114 - m_ScanImageButton.Height, 0, 0)
            'Adds the button control to the form.
            m_Grid.Children.Add(m_ScanImageButton)

            'Display the new created form.
            m_Form.Show()
        End Sub

        ''' <summary>
        ''' Load button click event.
        ''' </summary>
        ''' <param name="sender">Sender object.</param>
        ''' <param name="e">Event args.</param>
        Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles m_LoadButton.Click
            Dim m_OpenFile As New OpenFileDialog()
            m_OpenFile.Filter = "Supported Image Files |*.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.gif;*.png;*.cut;*.dds;*.g3;*.hdr;*.ico;*.iff;*.lbm;*.jng;*.koa;*.mng;*.pbm;*.pcd;*.pcx;*.pgm;*.ppm;*.psd;*.ras;*.sgi;*.tga;*.targa;*.wbmp;*.xbm;*.xpm;*.wmf;*.pdf;*.xps"
            If m_OpenFile.ShowDialog() = True Then
                'Display the selected image on the control.
                m_ImgEdit.ImageFilePath = m_OpenFile.FileName
                m_ImgEdit.Display()
                m_ImgEdit.FitTo(ImageComponents.WPF.Imaging.ImgEdit.ICImageFit.BestFit, True)
            End If
        End Sub

        ''' <summary>
        ''' Save button click event.
        ''' </summary>
        ''' <param name="sender">Sender object.</param>
        ''' <param name="e">Event args.</param>
        Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles m_SaveButton.Click
            Dim m_SaveFileDialog As New SaveFileDialog()
            m_SaveFileDialog.Filter = "Microsoft Windows Bitmap (*bmp)|*.bmp|JPEG File (*.jpg)|*.jpg|Tagged Image File Default Compression (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File Uncompressed (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File LZW (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File CCITT3 (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File CCITT4 (*.tif;*.tiff)|*.tif;*.tiff|Tagged Image File RLE (*.tif;*.tiff)|*.tif;*.tiff|Graphics Interchange Format (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Portable Document Format (*.pdf)|*.pdf"
            If m_SaveFileDialog.ShowDialog() = True Then
                Select Case m_SaveFileDialog.FilterIndex
                    Case 1
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.BMP
                        Exit Select
                    Case 2
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.JPEG
                        Exit Select
                    Case 3
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.[DEFAULT]
                        Exit Select
                    Case 4
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.NONE
                        Exit Select
                    Case 5
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.LZW
                        Exit Select
                    Case 6
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.CCITT3
                        Exit Select
                    Case 7
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.CCITT4
                        Exit Select
                    Case 8
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.TIFF
                        m_ImgEdit.SaveImageCompression = ImageComponents.WPF.Imaging.ImgEdit.ICImageCompression.RLE
                        Exit Select
                    Case 9
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.GIF
                        Exit Select
                    Case 10
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.PNG
                        Exit Select
                    Case 11
                        m_ImgEdit.SaveImageFormat = ImageComponents.WPF.Imaging.ImgEdit.ICImageOutputFormat.PDF
                        Exit Select
                End Select
                m_ImgEdit.SaveOutputType = ImageComponents.WPF.Imaging.ImgEdit.ICImageSaveOutputType.FileSystem
                m_ImgEdit.SaveImageAs(m_SaveFileDialog.FileName)
            End If
        End Sub

        ''' <summary>
        ''' Rotate left button click event.
        ''' </summary>
        ''' <param name="sender">Sender object.</param>
        ''' <param name="e">Event args.</param>
        Private Sub RotateLeftButton_Click(sender As Object, e As EventArgs) Handles m_RotateLeftButton.Click
            m_ImgEdit.RotateLeft()
        End Sub

        ''' <summary>
        ''' Rotate right button click event.
        ''' </summary>
        ''' <param name="sender">Sender object.</param>
        ''' <param name="e">Event args.</param>
        Private Sub RotateRightButton_Click(sender As Object, e As EventArgs) Handles m_RotateRightButton.Click
            m_ImgEdit.RotateRight()
        End Sub

        ''' <summary>
        ''' Scan image button click event.
        ''' </summary>
        ''' <param name="sender">Sender object.</param>
        ''' <param name="e">Event args.</param>
        Private Sub ScanImageButton_Click(sender As Object, e As EventArgs) Handles m_ScanImageButton.Click
            m_ImgScan.ImageAcquireMode = ImageComponents.WPF.Imaging.ImgScan.ICImageAcquireMode.Single
            m_ImgScan.SaveImageFormat = ImageComponents.WPF.Imaging.ImgScan.ICImageOutputFormat.TIFF
            m_ImgScan.SaveImageCompression = ImageComponents.WPF.Imaging.ImgScan.ICImageCompression.CCITT4
            m_ImgScan.DeviceTransferMode = ImageComponents.WPF.Imaging.ImgScan.ICImageTransferMode.Memory
            m_ImgScan.SaveFileNamePrefix = "IMG"
            m_ImgScan.ImageFileDirectory = System.AppDomain.CurrentDomain.BaseDirectory & "\\"
            m_ImgScan.RemoveBlankPages = False
            m_ImgScan.ImagePageSeparation = ImageComponents.WPF.Imaging.ImgScan.ICImagePageSeparationType.None
            m_ImgScan.ShowScannerUI = True
            If ([String].IsNullOrEmpty(m_ImgScan.ActiveSourceName)) Then
                If (m_ImgScan.SelectSource() = False) Then
                    Return
                End If
            End If
            m_ImgScan.Acquire()
        End Sub

    End Class
End Namespace