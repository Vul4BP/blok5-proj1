﻿using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blok5_P1.View
{
    /// <summary>
    /// Interaction logic for AddPhotoView.xaml
    /// </summary>
    public partial class AddPhotoView : UserControl
    {
        public AddPhotoView()
        {
            InitializeComponent();
            DataContext = new AddPhotoViewModel();
        }
    }
}
