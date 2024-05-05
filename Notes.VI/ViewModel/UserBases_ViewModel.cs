using Notes.APL.Common;
using Notes.APL.Model;
using Notes.BL;
using Notes.BLL.Models.custome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;

namespace Notes.APL.ViewModel
{
    class UserBases_ViewModel: BaseINPC
    {
        private NotesContextBL _context = new NotesContextBL();


        private int _userId;
        public int UserId
        {
            get => this._userId;
            set => SetField(ref _userId, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => this._firstName;
            set => SetField(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => this._lastName;
            set => SetField(ref _lastName, value);
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get => this._emailAddress;
            set => SetField(ref _emailAddress, value);
        }

        private string _password;
        public string Password
        {
            get => this._password;
            set => SetField(ref _password, value);
        }


        private string _role;
        public string Role
        {
            get => this._role;
            set => SetField(ref _role, value);
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get => this._phoneNumber;
            set => SetField(ref _phoneNumber, value);
        }


        public ObservableCollection<Model.UsersInfo> UsersInfo { get; set; }

        public BindingList<Model.UsersInfo> UsersInfos { get; set; }
        
        public List<Model.UsersInfo> PrevUserInfos { get; set; }



        public UserBases_ViewModel()
        {
            var users = _context.GetUsersInfo().Select(a => Mapper.MapFrom_UsersInfoBLL_To_UsersInfoAPL(a.UserId, a.FirstName, a.LastName, a.EmailAddress, a.Password, a.Role, a.PhoneNumber)).ToList();
           
            UsersInfo = new ObservableCollection<Model.UsersInfo>(users);

            UsersInfos = new BindingList<Model.UsersInfo>(users);

            PrevUserInfos = UsersInfos.ToList();

            UsersInfo.CollectionChanged += ObservableCollectionChanged; 
            UsersInfos.ListChanged += BindingListChanged;  
        }
                
        public void BindingListChanged(object sender, ListChangedEventArgs e)
        {

            if(e.ListChangedType.ToString() == "ItemChanged")
            {
                //MessageBox.Show($"Property name = {e.PropertyDescriptor.Name}");
                //MessageBox.Show($"NewIndex = {e.NewIndex}");
                //MessageBox.Show($"OldIndex = {e.OldIndex}");
                //MessageBox.Show($"IdUser = {UsersInfos.ToArray()[e.NewIndex].UserId}");


                var editId = UsersInfos.ToArray()[e.NewIndex].UserId;
                var editFirstName = UsersInfos.ToArray()[e.NewIndex].FirstName;
                var editLastName = UsersInfos.ToArray()[e.NewIndex].LastName;
                var editPassword = UsersInfos.ToArray()[e.NewIndex].Password;
                var editEmailAddress = UsersInfos.ToArray()[e.NewIndex].EmailAddress;
                var editPhoneNumber = UsersInfos.ToArray()[e.NewIndex].PhoneNumber;
                var editRole = UsersInfos.ToArray()[e.NewIndex].Role;

                this._context.UpdatePerson(editId, editFirstName, editLastName, editPassword, editEmailAddress, editPhoneNumber, editRole);
            }
            if (e.ListChangedType.ToString() == "ItemDeleted")
            {

                //MessageBox.Show($"NewIndex = {e.NewIndex}");
                //MessageBox.Show($"OldIndex = {e.OldIndex}");
                ////var r = UsersInfos.ToArray();
                //MessageBox.Show($"Deleted IdUser = {PrevUserInfos[e.NewIndex].UserId}");

                //foreach (var item in UsersInfos)
                //{
                //    MessageBox.Show($"Item{item.UserId} - {item.LastName}");
                //}

                //MessageBox.Show($"IdUser = {UsersInfos[e.NewIndex].UserId}");

                var delId = PrevUserInfos[e.NewIndex].UserId;
                this._context.DeletePersonCascade(delId);
            }



            PrevUserInfos = UsersInfos.ToList();
        }
        

        public void ObservableCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems?[0] is Model.UsersInfo oldPerson)
                {
                    this._context.DeletePersonCascade(oldPerson.UserId);
                }    
            }
            else if(e.Action == NotifyCollectionChangedAction.Move)
            {
                //if (e.NewItems?[0] is Model.UsersInfo newPerson)
                //{
                //    this._context.UpdatePerson(newPerson.UserId, newPerson.FirstName, newPerson.LastName, newPerson.Password, newPerson.EmailAddress, newPerson.PhoneNumber, newPerson.Role);
                //}

                if ((e.NewItems?[0] is Model.UsersInfo replacingPerson) && (e.OldItems?[0] is Model.UsersInfo replacedPerson))
                {
                    MessageBox.Show($"Объект {replacedPerson.FirstName} {replacedPerson.LastName} {replacedPerson.EmailAddress} заменен объектом {replacingPerson.FirstName} {replacingPerson.LastName} {replacingPerson.EmailAddress}");
                }
                   


            }
        }
    }
}
