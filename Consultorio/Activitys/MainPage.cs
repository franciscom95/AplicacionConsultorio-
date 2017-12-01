using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
    public sealed class MainPage
    {
        #region [ Constants ]

        const string configUserName = "jcgonzalez";
        const string configPassword = "K?)@5E9LgYhnZs";

        #endregion

        #region [ Fields ]

        private static MainPage s_instance;

        private List<Tuple<int, string>> rawList;

        #endregion

        #region [ Properties ]

        public static MainPage Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = new MainPage();

                return s_instance;
            }
        }

        public int actualpaciente { get; set; }      

        #endregion

        #region [ Constructors ]

        private MainPage( )
        {
            //this.mainActivity = mainActivity;
        }

        #endregion

     

    }
