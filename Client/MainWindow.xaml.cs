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
﻿using Client.ServiceReference1;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FoolServiceClient client = new FoolServiceClient();

        int MyUserId;

        void Update()
        {
            // получаем карты, обновляем их на столе
            Dictionary<int, int> CardOnTable = client.GetCardsOnTable();
            // ######### тут нужно обновить каты на столе


            // получаем всех юзеров и обновляем их статусы
            List<User> AllUsers = client.GetAllUsersOnTable().ToList();
            // ######### тут нужно обновить статусы всех юзеров


            // тут работаем со своим юзером
            User MyUser = AllUsers[MyUserId];
            List<int> MyCards = MyUser.cards.ToList();
            // ######### тут нужно обновить карты своего юзера

            int MyStatus = MyUser.status;
            
            // ######### тут в зависимости от статуса либо ожидание либо дается возможность выполнения какого-то действия
            switch (MyStatus)
            {
                case 0:
                    //ожидание
                    break;
                case 1:
                    //ходи
                    break;
                default:
                    break;
            }

        }

        public MainWindow()
        {
            InitializeComponent();

            User user = client.Registration("Вяся");
        }

    }
}
