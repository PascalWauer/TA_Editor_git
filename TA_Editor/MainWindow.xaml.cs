﻿using System;
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
using System.IO;

namespace TA_Editor
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public DataGrid DataGridTDF
        {
            get
            {
                return m_DataGridTDF;
            }
        }

        public DataGrid DataGridFBI
        {
            get
            {
                return m_DataGridFBI;
            }
        }

        //public DataGrid DataGridFBI_Eco
        //{
        //    get
        //    {
        //        return m_DataGridFBI_Eco;
        //    }
        //}

        private void OnButtonReadDataClick(object sender, RoutedEventArgs e)
        {
            TACommands.ReadAllTDFFilesCommand.Execute(null, this);

            string folderPath = @"E:\Privat\Rev31\rev31\Weapons";
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.tdf"))
            {

            }
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void OnInformationClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Info\r" +
                "\r" +
                "This tool is designed to manipulate Total Annihilation data files.\r" +
                "Before you can read any data you need to extract the .ufo, .hpi or .gp3 files you want to manipulate (HPIviewer can help here). \r" +
                "\r" +
                "When you have extracted all the files, you need to specify the folder path where you have extracted the files. \r" +
                "This folder must have a folder containing the word 'unit' including .fbi files. It must have a folder containg the word 'weapon' including .tdf files if you want to edit weapon files. \r"+
                "It is suggested to make a backup of all WEAPONS and UNITS folders before starting to edit the files.\r" +
                "\r" +
                "Click on the specific button to read unit or weapon files. Weapons are always corresponding to the shown units. So be sure to read some units first. \r" +
                "\r" +
                "Edit the values in the specific cells manually or use the calculation functions on the selected cells.\r" +
                "After you are finished you need to SAVE the edited data. This will replace all changed files in the original folder with the values in the table. \r" +
                "The last step to do is to pack the folder back to its original file (HPIpacker can help here) and place it into your TA folder. \r" +
                "\r" +
                "The author of this program is Pascal Wauer. Using this program is under your own responsibility." +
                "\r"
                , "Total Annihilation Units and Weapons Editor V1.12"
                );
        }

        private void OnShowEcoClick(object sender, RoutedEventArgs e)
        {
            this.DataGridFBI.SelectedCells.Clear();
        }

        private void OnSelectionChangedFBI(object sender, SelectedCellsChangedEventArgs e)
        {
            this.DataGridTDF.SelectedCells.Clear();
        }

        private void OnSelectionChangedTDF(object sender, SelectedCellsChangedEventArgs e)
        {
            this.DataGridFBI.SelectedCells.Clear();
        }

        private void OnCellRightClickClick(object sender, MouseButtonEventArgs e)
        {
            TACommands.OnCellRightClickClick.Execute(null, this);
        }
    }
}
