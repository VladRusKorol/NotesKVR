using Notes.APL.Common;
using Notes.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.ViewModel
{
    public class MainWindow_ViewModel: BaseINPC
    {
        //-----------------------------------------------------------------------
        private NotesContextBL _context = new NotesContextBL();
        private ResourceDictionary _myResDic = new ResourceDictionary();
        //-----------------------------------------------------------------------
        private string _firstName;
        public string FirstName
        {
            get => _firstName; 
            set => SetField(ref _firstName, value);
        }
        //-----------------------------------------------------------------------
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetField(ref _lastName, value);
        }
        //-----------------------------------------------------------------------
        private string _currentPageAdress;
        public string CurrentPageAdress
        {
            get => _currentPageAdress;
            set => SetField(ref _currentPageAdress, value);
        }
        //-----------------------------------------------------------------------
        public LambdaCommand NotesPageRedirectCommand { get; set; }
        public LambdaCommand NewNotesPageRedirectCommand { get; set; }
        public LambdaCommand UserBasesRedirectCommand { get; set; }
        public LambdaCommand OptionsRedirectCommand { get; set; }
        public LambdaCommand FAQRedirectCommand { get; set; }
        public LambdaCommand ExitCommand { get; set; }
        //-----------------------------------------------------------------------
        public MainWindow_ViewModel() 
        {
            FirstName = (string)Application.Current.Resources.FindName("UserFirstName") ?? "none";
            LastName = (string)Application.Current.Resources.FindName("UserLastName") ?? "none";

            CurrentPageAdress = "..\\..\\..\\View\\Pages\\NotesPage.xaml";

            NotesPageRedirectCommand = new LambdaCommand(
                    canExecute: _ => CurrentPageAdress != "..\\..\\..\\View\\Pages\\NotesPage.xaml",
                    execute: _ => CurrentPageAdress = "..\\..\\..\\View\\Pages\\NotesPage.xaml"
                );
            NewNotesPageRedirectCommand = new LambdaCommand(
                    canExecute: _ => CurrentPageAdress != "..\\..\\..\\View\\Pages\\NewNotesPage.xaml",
                    execute: _ => CurrentPageAdress = "..\\..\\..\\View\\Pages\\NewNotesPage.xaml"
                );

            UserBasesRedirectCommand = new LambdaCommand(
                    canExecute: _ => CurrentPageAdress != "..\\..\\..\\View\\Pages\\UserBases.xaml",
                    execute: _ => CurrentPageAdress = "..\\..\\..\\View\\Pages\\UserBases.xaml"
                );
            OptionsRedirectCommand = new LambdaCommand(
                    canExecute: _ => CurrentPageAdress != "..\\..\\..\\View\\Pages\\OptionsPage.xaml",
                    execute: _ => CurrentPageAdress = "..\\..\\..\\View\\Pages\\OptionsPage.xaml"
                );
            FAQRedirectCommand = new LambdaCommand(
                        canExecute: _ => CurrentPageAdress != "..\\..\\..\\View\\Pages\\FAQ.xaml",
                        execute: _ => CurrentPageAdress = "..\\..\\..\\View\\Pages\\FAQ.xaml"
                    );

            ExitCommand = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ => {

                        Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                        Application.Current.Shutdown();
                    }
                );
        }
    }
}
