﻿using App;
using App.Gwin;
using App.Gwin.Application.Presentation.EntityManagement;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Entities;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.Secrurity.Authentication;
using RH_managementSolution.BAL;
using RH_managementSolution.DAL;
using SplashScreen;
using System;
using System.Windows.Forms;

namespace GenericWinForm.Demo
{
    public partial class FormMenuApplication : FormApplication
    {
        public FormMenuApplication()
        {
            InitializeComponent();
        }

        private void FormMenuApplication_Load(object sender, EventArgs e)
        {
            User user = null;

            //   user = User.CreateGuestUser(new ModelContext());
            user = User.CreateAdminUser(new ModelContext());
          //  user = User.CreateRootUser(new ModelContext());

            // Start Gwin Application with Authentification
            user.Language = GwinApp.Languages.fr;
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), this, user);

        }
        /// <summary>
        /// Reload the form after language change
        /// </summary>
        public override void Reload()
        {
            base.Reload();
            InitializeComponent();
        }

    }
}
