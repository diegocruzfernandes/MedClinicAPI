﻿using Flunt.Notifications;
using Flunt.Validations;
using MedServer.Domain.Shared;
using MedServer.Domain.ValueObjects;
using System;

namespace MedServer.Domain.Entities
{
    public class User : Notifiable
    {
        #region Ctor
        protected User() { }

        public User(int id, string email, string password, string nickname, EPermission permission, bool enabled)
        {
            Id = id;
            Email = email;
            Password = password;
            Nickname = nickname;
            Permission = permission;
            Enabled = enabled;

            Validate();
            Password = ValidationPassword.Encrypt(Password);
        }
        #endregion

        #region Attributes
        public int Id { get;  set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Nickname { get; private set; }
        public EPermission Permission { get; private set; }
        public bool Enabled { get; private set; }
        #endregion

        #region Methods
        public bool Authenticate(string email, string password)
        {
            if (Email == email && Password == ValidationPassword.Encrypt(password))
                return true;

            AddNotification("User", "Usuário ou senha inválido!");
            return false;
        }

        public string ResetPassword()
        {
            string pass = Guid.NewGuid().ToString().Substring(0, 6);
            Password = ValidationPassword.Encrypt(pass);
            return pass;
        }

        public void Activate() => Enabled = true;

        public void Deactivate() => Enabled = false;

        public void ChangeNickname(string nickname)
        {
            Nickname = nickname;
            Validate();
        }

        public void ChangePermission(EPermission permission)
        {
            Permission = permission;
        }

        public string[] GetListPermission()
        {
            string[] list;

            switch (Permission)
            {
                case EPermission.Admin:
                    list = new string[]{ EPermission.Admin.ToString(), EPermission.Doctor.ToString(), EPermission.Secretary.ToString(), EPermission.User.ToString() };
                    break;
                case EPermission.Doctor:
                    list = new string[] { EPermission.Doctor.ToString(), EPermission.Secretary.ToString(), EPermission.User.ToString() };
                    break;
                case EPermission.Secretary:
                    list = new string[] { EPermission.Secretary.ToString(), EPermission.User.ToString() };
                    break;
                case EPermission.User:
                    list = new string[] {EPermission.User.ToString() };
                    break;
                default:
                    list = new string[] { EPermission.User.ToString() };
                    break;
            }
            return list;
        }

        public void Validate() => AddNotifications(new Contract()
               .IsEmail(Email, "Email", "O E-Mail não é válido")
               .HasMaxLen(Email, 60, "Name", "O Nome não pode ter mais que 60 caracteres")
               .HasMinLen(Nickname, 3, "Nickname", "O Nickname não pode ter menos que 3 caracteres")
               .HasMaxLen(Nickname, 60, "Nickname", "O Nickname não pode ter mais que 60 caracteres")
               .HasMinLen(Password, 3, "Password", "A Senha deve ter no mínimo 3 caracteres")
               .HasMaxLen(Password, 60, "Password", "A Senha deve ter no máximo 60 caracteres")
           );
        #endregion
    }
}
