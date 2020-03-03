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

namespace Loting.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<string> ploegenBeschikbaar = new List<string>();
        List<string> ploegenNietBeschikbaar = new List<string>();
        
        
        Random random = new Random();
       

        public MainWindow()
        {
            InitializeComponent();
        }
        void VulListbox()
        {
            lstBeschikbaar.ItemsSource = ploegenBeschikbaar;
            lstBeschikbaar.Items.Refresh();
            lstGekozen.ItemsSource = ploegenNietBeschikbaar;
            lstGekozen.Items.Refresh();
           
        }
        void VulPloegen()
        {
            ploegenBeschikbaar.Add("Clepsy Paulas");
            ploegenBeschikbaar.Add("Siggid Stardust");
            ploegenBeschikbaar.Add("Nerdy birdies");
            ploegenBeschikbaar.Add("Outsiders");
            ploegenBeschikbaar.Add("Max Energy");
            ploegenBeschikbaar.Add("Young once");
            ploegenBeschikbaar.Add("Wonderfull Willies");
            ploegenBeschikbaar.Add("Soetigheid");
            
        }

        void LootPloegen()
        {
            int index;
            int index2;
            //check of random getal niet 2 keer het zelfde is.
            do
            {
                index = random.Next(0, ploegenBeschikbaar.Count);
                index2 = random.Next(0, ploegenBeschikbaar.Count);
            }
            while (index == index2);

            //Voeg Gekozen ploegen toe aan "niet beschikbaar"
            ploegenNietBeschikbaar.Add(ploegenBeschikbaar[index]);
            ploegenNietBeschikbaar.Add(ploegenBeschikbaar[index2]);
            //geef weer in lst matchen
            lstMatchen.Items.Add(ploegenBeschikbaar[index] + " vs " + ploegenBeschikbaar[index2]);

            //zorg ervoor dat het de ploeg met de grootste index eerst verwijderd word.
            if (index > index2)
            {
                ploegenBeschikbaar.RemoveAt(index);
                ploegenBeschikbaar.RemoveAt(index2);
            }
            else
            {

                ploegenBeschikbaar.RemoveAt(index2);
                ploegenBeschikbaar.RemoveAt(index);
            }
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulPloegen();
            VulListbox();
        }

        private void btnLoot_Click(object sender, RoutedEventArgs e)
        {
         
                LootPloegen();
                VulListbox();
            if (ploegenBeschikbaar.Count == 0) btnLoot.IsEnabled = false;


        }
    }
}
