using FoolService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class TableStatic
    {
        static int max_users = 6;

        public static List<User> users = new List<User>();

        // кто ходит
        static int AttacUserId = 0;

        // карты на столе
        public static Dictionary<int, int> CartOnTable = new Dictionary<int, int>();

        // колода карт
        static Deck desk = new Deck();


        // НАЧАТЬ ИГРУ
        public static void PlayGame()
        {
            //В цикле проходим по всем юзерам и раздаём по 6 карт
            for (int i = 0; i < 6; i++)
            {
                foreach (var user in users)
                {
                    user.cards.Add(desk.cards.Last());
                    desk.cards.Remove(desk.cards.Last());
                }
            }

            //Отправляем информацию юзерам
            //все - ожидание
            foreach (var user in users)
                user.status = 0;
            //AttacUser - ходи
            users[AttacUserId].status = 1;
        }


        // ПОШЕЛ
        public bool Go(int current_card)
        {
            // положили карту, которую будем крыть, на стол 
            if (CartOnTable.Count < 6)
            {
                // добавляем катру в словарь
                CartOnTable[current_card] = -1;

                // отбивающийся
                int BeatUserId = GetNextId(AttacUserId);

                //Обновляем статусы
                //все - ожидание
                foreach (var user in users)
                    user.status = 0;

                // если есть неотбитые карты - отбивающийся отбивается
                if (NotTappedMap())
                    users[BeatUserId].status = 2;

                // если на столе меньше 6 карт - крайние подкидывают
                if (CartOnTable.Count < 6)
                {
                    users[AttacUserId].status = 1; //подкидывает тот кто ходил

                    int OtherUserId = GetNextId(BeatUserId);
                    users[OtherUserId].status = 1; //подкидывает другой
                }

                return true;
            }
            return false;            
        }


        // ВЗЯЛ
        public bool Take()
        {
            // отбивающийся
            int BeatUserId = GetNextId(AttacUserId);

            // складываем все карты тому, кто взял
            foreach (var item in CartOnTable)
            {
                users[BeatUserId].cards.Add(item.Key);
                if (item.Value != -1)
                    users[BeatUserId].cards.Add(item.Value);
            }

            // убираем карты на столе
            CartOnTable = new Dictionary<int, int>();

            // обновляем статусы
            //все - ожидание
            foreach (var user in users)
                user.status = 0;

            // новый нападающий
            AttacUserId = GetNextId(BeatUserId);
            users[AttacUserId].status = 1;

            // тут всем доложить карты

            return true;
        }


        //метот есть ли не отбитые карты
        bool NotTappedMap()
        {
            foreach (var item in CartOnTable)
            {
                if (item.Value == -1)
                    return true;
            }
            return false;
        }

        //получть id следующего
        int GetNextId(int CurrentUserId)
        {
            return (CurrentUserId + 1) % users.Count;
        }

        //получть id предыдущего
        int GetPrevId(int CurrentUserId)
        {
            int id = CurrentUserId - 1;
            if (id == -1)
                return users.Count - 1;
            else
                return id;
        }
        
    }
}
