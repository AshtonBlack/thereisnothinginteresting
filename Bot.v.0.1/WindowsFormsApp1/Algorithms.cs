namespace WindowsFormsApp1
{
    public class Algorithms
    {
        public double CalculateCompatibility(string track, string coverage, string weather, double[] carstats)
        {            
            double clearance = carstats[0];
            double tires = carstats[1];
            double drive = carstats[2];
            double acceleration = carstats[3];
            double maxSpeed = carstats[4];
            double grip = carstats[5];
            double weight = carstats[6];

            double x = 0;
            switch (coverage)
            {
                case "Асфальт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (tires)
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
                            if (drive == 4) x -= 50;
                            break;
                        case "Дождь":
                            switch (tires)
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    if (drive == 4) x += 50;
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
                            switch (tires)
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
                    switch (tires)
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
                    if (drive == 4) x += 50;
                    break;
                case "Грунт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (tires)
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
                            if (drive == 4) x += 50;
                            break;
                        case "Дождь":
                            switch (tires)
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
                            if (drive == 4) x += 100;
                            break;
                        default:
                            switch (tires)
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
                    switch (tires)
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
                    if (drive == 4) x += 50;
                    break;
                case "Снег":
                    switch (tires)
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
                    if (drive == 4) x += 100;
                    break;
                case "Смешанное":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (tires)
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
                            switch (tires)
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
                            switch (tires)
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
                    if (drive == 4) x += 50;
                    break;
                case "Трава":
                    switch (tires)
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
                    if (drive == 4) x += 50;
                    break;
                case "Лед":
                    switch (tires)
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
                    if (drive == 4) x += 50;
                    break;
            }

            switch (track)
            {
                case "Улица ср":
                    switch (clearance)
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
                    x -= maxSpeed;
                    x -= grip*4;
                    break;
                case "Улица мал":
                    switch (clearance)
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
                    x -= maxSpeed;
                    x -= grip*5;
                    break;
                case "Подъем на холм":
                    switch (clearance)
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
                    x -= acceleration * 50;
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 400;
                    }
                    break;
                case "Трасса для мотокросса":
                    switch (clearance)
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
                    switch (clearance)
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
                    if(coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }                    
                    x -= acceleration * 200;
                    x -= grip;
                    x += maxSpeed * 5;
                    if (maxSpeed < 150)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    x -= acceleration * 200;
                    x -= grip;
                    x += maxSpeed * 5;
                    if (maxSpeed < 130)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 200;
                    }
                    x -= acceleration * 100;
                    x -= grip*5;
                    x += maxSpeed * 2;
                    if (maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100-0":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 200;
                    }
                    x -= acceleration * 100;
                    x -= grip*5;
                    x += maxSpeed * 2;
                    if (maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "1":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 100;
                    }
                    x -= acceleration * 80;
                    x -= grip * 5;
                    x += maxSpeed * 3;
                    break;
                case "1/2":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 200;
                    }
                    x -= acceleration * 80;
                    x -= grip * 5;
                    x += maxSpeed;
                    break;
                case "1/4":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 300;
                    }
                    x -= acceleration * 120;
                    x -= grip * 5;
                    x += maxSpeed / 2;
                    break;
                case "0-60":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 300;
                    }
                    x -= acceleration * 120;
                    x -= grip*5;
                    if(maxSpeed < 60)
                    {
                        x -= 2000;
                    }
                    break;
                case "Токио трасса":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += maxSpeed;
                    break;
                case "Трасса набережная":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += maxSpeed;
                    break;
                case "Тестовый круг":
                    if (coverage == "Асфальт")
                    {
                        if (tires == 2)
                        {
                            x += 200;
                        }
                        if (drive == 4)
                        {
                            x -= 200;
                        }
                    }
                    x += maxSpeed * 5;
                    x -= grip*10;
                    break;
                case "Токио мостик":
                    x += maxSpeed * 3;
                    x -= acceleration * 6;
                    break;
                case "Нюрбург 1":
                    x -= acceleration * 60;
                    x += maxSpeed * 3;
                    x += grip;
                    break;
                case "Нюрбург 2":
                    x -= acceleration * 60;
                    x += maxSpeed * 3;
                    x += grip;
                    break;
                case "Нюрбург 3":
                    x -= acceleration * 60;
                    x += maxSpeed * 3;
                    x += grip;
                    break;
                case "Нюрбург 4":
                    x -= acceleration * 60;
                    x += maxSpeed * 3;
                    x += grip;
                    break;
                case "Нюрбург 5":
                    x -= acceleration * 60;
                    x += maxSpeed * 3;
                    x += grip;
                    break;
                case "Токио петля":
                    x += maxSpeed * 2;
                    x -= acceleration * 80;
                    break;
                case "Замерзшее озеро":
                    break;
                case "Горы серпантин":
                    if (coverage != "Асфальт" || weather != "Солнечно")
                    {
                        if (drive == 4) x += 100;
                    }                        
                    break;
                case "Горы извилистая дорога":
                    break;
                case "Горы дорога с уклоном":
                    break;
                case "Горы подъем на холм":
                    switch (clearance)
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
                    x -= acceleration * 50;
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 400;
                    }                    
                    break;
                case "Горная экспедиция":
                    x += maxSpeed;
                    break;
                case "Извилистая дорога":
                    if (coverage != "Асфальт")
                    {
                        switch (clearance)
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
                        if (drive == 4) x += 50;
                    }
                    break;
                case "Быстрая трасса":
                    x -= acceleration * 40;
                    x -= grip / 2;
                    x += maxSpeed;
                    break;
                case "Highway":
                    x -= acceleration * 40;
                    x -= grip / 2;
                    x += maxSpeed;
                    break;
                case "Монако длинные городские улицы":
                    x -= acceleration * 40;
                    x -= grip / 2;
                    x += maxSpeed;
                    break;
                case "Каньон экспедиция":
                    x -= acceleration * 30;
                    x -= grip / 4;
                    x += maxSpeed;
                    break;
                case "Серпантин":
                    x -= acceleration * 50;
                    break;
                case "Монако серпантин":
                    x -= acceleration * 50;
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