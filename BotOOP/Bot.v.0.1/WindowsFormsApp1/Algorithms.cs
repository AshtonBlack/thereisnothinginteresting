namespace WindowsFormsApp1
{
    public class Algorithms
    {
        public double CalculateCompatibility(string track, string coverage, string weather, double[] carstats)
        {
            //carstats[0клиренс, 1резина, 2привод, 3разгон до сотки, 4максималка, 5управление, 6масса]
            /*
            1 - slk
            2 - dyn
            3 - std
            4 - all
            5 - off            
            */
            double x = 0;
            switch (coverage)
            {
                case "Асфальт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 500;
                                    break;
                                case 2:
                                    x += 400;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 200;
                                    break;
                            }
                            if (carstats[2] == 4) x -= 50;
                            break;

                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    if (carstats[2] == 4) x += 50;
                                    x += 200;
                                    break;
                                case 3:
                                    x += 500;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 200;
                                    break;
                                case 3:
                                    x += 500;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Гравий":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 100;
                            break;
                        case 3:
                            x += 300;
                            break;
                        case 4:
                            x += 450;
                            break;
                        case 5:
                            x += 250;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Грунт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 100;
                                    break;
                                case 2:
                                    x += 100;
                                    break;
                                case 3:
                                    x += 250;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            if (carstats[2] == 4) x += 50;
                            break;
                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            if (carstats[2] == 4) x += 100;
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Песок":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 250;
                            break;
                        case 4:
                            x += 500;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Снег":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 500;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 100;
                    break;
                case "Смешанное":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 300;
                                    break;
                            }
                            break;
                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 250;
                                    break;
                            }
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Трава":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 350;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Лед":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 400;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
            }

            switch (track)
            {
                case "Улица ср":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 700;
                            break;
                        case 3:
                            x += 300;
                            break;
                    }

                    x -= carstats[4];
                    x -= carstats[5];
                    break;
                case "Улица мал":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 700;
                            break;
                        case 3:
                            x += 300;
                            break;
                    }

                    x -= carstats[4];
                    x -= carstats[5];
                    break;
                case "Подъем на холм":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 200;
                            break;
                        case 3:
                            x += 500;
                            break;
                    }
                    x -= carstats[3] * 50;
                    if (carstats[2] == 4) x += 200;
                    break;
                case "Трасса для мотокросса":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 200;
                            break;
                        case 3:
                            x += 500;
                            break;
                    }
                    break;
                case "Мотокросс":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 200;
                            break;
                        case 3:
                            x += 500;
                            break;
                    }
                    break;
                case "50-150":
                    x -= carstats[3] * 200;
                    x -= carstats[5];
                    x += carstats[4] * 5;
                    break;
                case "75-125":
                    x -= carstats[3] * 200;
                    x -= carstats[5];
                    x += carstats[4] * 5;
                    break;
                case "0-100":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4] * 2;
                    break;
                case "0-100-0":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4] * 2;
                    break;
                case "1":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 100;
                    }
                    x -= carstats[3] * 80;
                    x -= carstats[5];
                    x += carstats[4] * 3;
                    break;
                case "1/2":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 80;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "1/4":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 300;
                    }
                    x -= carstats[3] * 120;
                    x -= carstats[5];
                    x += carstats[4] / 2;
                    break;
                case "Токио трасса":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "Трасса набережная":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "Тестовый круг":
                    x += carstats[4] * 5;
                    x -= carstats[5];
                    break;
                case "Токио мостик":
                    x += carstats[4] * 3;
                    x -= carstats[3] * 6;
                    break;
                case "Нюрбург 1":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 2":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 3":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 4":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 5":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Токио петля":
                    x += carstats[4] * 2;
                    x -= carstats[3] * 80;
                    break;
                case "Замерзшее озеро":
                    break;
                case "Горы серпантин":
                    if (carstats[2] == 4) x += 100;
                    break;
                case "Горы извилистая дорога":
                    break;
                case "Извилистая дорога":
                    if (coverage != "Асфальт")
                    {
                        switch (carstats[0])
                        {
                            case 1:
                                x += 0;
                                break;
                            case 2:
                                x += 200;
                                break;
                            case 3:
                                x += 300;
                                break;
                        }
                        if (carstats[2] == 4) x += 50;
                    }
                    break;
                case "Быстрая трасса":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Highway":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Монако длинные городские улицы":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Каньон экспедиция":
                    x -= carstats[3] * 30;
                    x -= carstats[5] / 4;
                    x += carstats[4];
                    break;
                case "Серпантин":
                    x -= carstats[3] * 50;
                    break;
                case "Монако серпантин":
                    x -= carstats[3] * 50;
                    break;
                case "Извилистая трасса":
                    break;
                case "Токио мост":
                    break;
                case "Токио съезд":
                    break;
                case "Монако городские":
                    break;
                case "Обзор":
                    break;
                case "Каньон грунтовая дорога":
                    break;
                case "Грунтовая дорога":
                    break;
                case "Каньон крутой холм":
                    break;
                case "Лесная переправа":
                    break;
                case "Ралли-кросс мал":
                    break;
                case "Ралли-кросс ср":
                    break;
                case "Крутой холм":
                    break;
                case "Лесная дорога":
                    break;
                case "Монако узкие улицы":
                    break;
                case "Монако тест на перегрузки":
                    break;
                case "Токио тест на перегрузки":
                    break;
                case "Трасса для картинга":
                    break;
                case "Парковка":
                    break;
                case "Лесной слалом":
                    break;
                case "Закрытый картинг":
                    break;
                case "Горы слалом":
                    break;
                case "Слалом":
                    break;
                case "Перегрузка":
                    break;
                case "Неизвестная трасса":
                    break;
                default:
                    NotePad.DoErrorLog("Написать логику для " + track);
                    break;
            }

            return x;
        }
    }
}