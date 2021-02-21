namespace WindowsFormsApp1 //universal
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
                            break;
                        case "Дождь":
                            if (drive == 4) x += 50;
                            switch (tires)
                            {
                                case 1:
                                    x -= 500;
                                    break;
                                case 2:                                    
                                    x -= 200;
                                    break;
                                case 3:
                                    x += 0;
                                    break;
                                case 4:
                                    x -= 100;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "Гравий":
                    switch (tires)
                    {
                        case 1:
                            x -= 300;
                            break;
                        case 2:
                            x -= 250;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x -= 50;
                            break;
                        case 5:
                            x += 0;
                            break;
                    }
                    if (drive == 4) x += 100;
                    break;
                case "Грунт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (tires)
                            {
                                case 1:
                                    x -= 400;
                                    break;
                                case 2:
                                    x -= 300;
                                    break;
                                case 3:
                                    x -= 200;
                                    break;
                                case 4:
                                    x -= 50;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            if (drive == 4) x += 100;
                            break;
                        case "Дождь":
                            switch (tires)
                            {
                                case 1:
                                    x -= 1000;
                                    break;
                                case 2:
                                    x -= 800;
                                    break;
                                case 3:
                                    x -= 300;
                                    break;
                                case 4:
                                    x -= 100;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            if (drive == 4) x += 200;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Песок":
                    switch (tires)
                    {
                        case 1:
                            x -= 300;
                            break;
                        case 2:
                            x -= 250;
                            break;
                        case 3:
                            x -= 150;
                            break;
                        case 4:
                            x -= 50;
                            break;
                        case 5:
                            x += 0;
                            break;
                    }
                    if (drive == 4) x += 100;
                    break;
                case "Снег":
                    switch (tires)
                    {
                        case 1:
                            x -= 1000;
                            break;
                        case 2:
                            x -= 800;
                            break;
                        case 3:
                            x -= 300;
                            break;
                        case 4:
                            x -= 100;
                            break;
                        case 5:
                            x += 0;
                            break;
                    }
                    if (drive == 4) x += 150;
                    break;
                case "Смешанное":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (tires)
                            {
                                case 1:
                                    x -= 300;
                                    break;
                                case 2:
                                    x -= 200;
                                    break;
                                case 3:
                                    x -= 0;
                                    break;
                                case 4:
                                    x -= 0;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            break;
                        case "Дождь":
                            switch (tires)
                            {
                                case 1:
                                    x -= 1000;
                                    break;
                                case 2:
                                    x -= 600;
                                    break;
                                case 3:
                                    x -= 300;
                                    break;
                                case 4:
                                    x -= 0;
                                    break;
                                case 5:
                                    x -= 300;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    if (drive == 4) x += 200;
                    break;
                case "Трава":
                    switch (tires)
                    {
                        case 1:
                            x -= 1000;
                            break;
                        case 2:
                            x -= 800;
                            break;
                        case 3:
                            x -= 300;
                            break;
                        case 4:
                            x -= 100;
                            break;
                        case 5:
                            x += 0;
                            break;
                    }
                    if (drive == 4) x += 150;
                    break;
                case "Лед":
                    switch (tires)
                    {
                        case 1:
                            x -= 1000;
                            break;
                        case 2:
                            x -= 800;
                            break;
                        case 3:
                            x -= 500;
                            break;
                        case 4:
                            x -= 200;
                            break;
                        case 5:
                            x += 0;
                            break;
                    }
                    if (drive == 4) x += 150;
                    break;
            }

            switch (track)
            {
                case "Длинная трасса у океана":                    
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed;
                    break;
                case "Короткая трасса у океана":                    
                    x -= acceleration * 120;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed / 2;
                    break;
                case "Магистраль у океана":
                    x += maxSpeed;
                    x -= acceleration * 50;
                    x += grip;
                    break;
                case "Парковка у океана":
                    x -= acceleration * 30;
                    x += grip * 8;
                    x -= weight;
                    break;
                case "Пляжный слалом у океана":
                    x -= acceleration * 30;
                    x += grip * 8;
                    x -= weight;
                    break;
                case "Городские улицы у океана":
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
                    break;
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
                    break;
                case "Подъем на холм":                    
                    x -= acceleration * 50;
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 400;
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
                    }
                    break;
                case "Трасса для мотокросса":
                    if (drive == 4) x += 100;
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
                    x -= acceleration * 100;
                    x -= grip;
                    x += weight / 10;
                    x += maxSpeed * 10;
                    if (maxSpeed < 150)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    x -= acceleration * 150;
                    x -= grip;
                    x += weight / 10;
                    x += maxSpeed * 5;
                    if (maxSpeed < 130)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100":
                    x -= acceleration * 200;
                    x -= grip*5;
                    x += weight / 10;
                    x += maxSpeed * 2;
                    if (maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100-0":
                    x -= acceleration * 100;
                    x -= grip*5;
                    x += weight / 10;
                    x += maxSpeed * 2;
                    if (maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "1":
                    x -= acceleration * 80;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed * 3;
                    break;
                case "1/2":
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed;
                    break;
                case "1/4":
                    x -= acceleration * 120;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed / 2;
                    break;
                case "0-60":
                    x -= acceleration * 120;
                    x -= grip*5;
                    x += weight / 10;
                    if (maxSpeed < 60)
                    {
                        x -= 2000;
                    }
                    break;
                case "Токио трасса":
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed;
                    break;
                case "Трасса набережная":
                    x -= acceleration * 100;
                    x -= grip * 5;
                    x += weight / 10;
                    x += maxSpeed;
                    break;
                case "Тестовый круг":
                    x += maxSpeed * 5;
                    x -= grip*10;
                    x += weight / 10;
                    break;
                case "Токио мостик":
                    x += maxSpeed * 3;
                    x -= acceleration * 6;
                    break;
                case "Нюрбург 1":
                    x += maxSpeed * 3;
                    break;
                case "Нюрбург 2":
                    x += maxSpeed * 3;
                    break;
                case "Нюрбург 3":
                    x += maxSpeed * 3;
                    break;
                case "Нюрбург 4":
                    x += maxSpeed * 3;
                    break;
                case "Нюрбург 5":
                    x += maxSpeed * 3;
                    break;
                case "Токио петля":
                    x += maxSpeed * 2;
                    x -= acceleration * 80;
                    break;
                case "Замерзшее озеро":
                    if (tires == 5)
                    {
                        x += 500;
                    }
                    if (tires == 4)
                    {
                        x += 200;
                    }
                    break;
                case "Горы серпантин":
                    if (coverage != "Асфальт" || weather != "Солнечно")
                    {
                        if (drive == 4) x += 100;
                    }                        
                    break;
                case "Горы извилистая дорога":
                    x -= acceleration * 30;
                    x += grip * 4;
                    break;
                case "Горы дорога с уклоном":
                    x += maxSpeed;
                    x -= acceleration * 50;
                    x += grip;
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
                    x += grip;
                    if (coverage != "Асфальт")
                    {
                        if (drive == 4) x += 400;
                    }                    
                    break;
                case "Горная экспедиция":
                    x += maxSpeed;
                    x += grip / 2;
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
                                x += 400;
                                break;
                        }
                        if (drive == 4) x += 50;
                    }
                    break;
                case "Быстрая трасса":
                    x -= acceleration * 40;
                    x -= grip / 2;
                    x += weight / 5;
                    x += maxSpeed*2;
                    break;
                case "Highway":
                    x -= acceleration * 40;
                    x += weight / 5;
                    x += grip*2;
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
                    x += grip;
                    break;
                case "Извилистая трасса":
                    x -= acceleration * 20;
                    x += grip*10;
                    break;
                case "Токио мост":
                    x += maxSpeed * 2;
                    x -= acceleration * 50;
                    x += grip;
                    break;
                case "Токио съезд":
                    x += maxSpeed * 2;
                    x -= acceleration * 50;
                    x += grip;
                    break;
                case "Монако городские":
                    x += maxSpeed * 2;
                    x -= acceleration * 50;
                    x += grip;
                    break;
                case "Обзор":
                    x += maxSpeed * 2;
                    x -= acceleration * 50;
                    x += grip;
                    break;
                case "Каньон грунтовая дорога":
                    x -= acceleration * 40;
                    x += grip * 2;
                    break;
                case "Каньон крутой холм":
                    x -= acceleration * 40;
                    x += grip * 2;
                    break;
                case "Лесная переправа":
                    x -= acceleration * 40;
                    x += grip * 2;
                    break;
                case "Ралли-кросс мал":
                    x -= acceleration * 40;
                    x += grip * 2;
                    break;
                case "Ралли-кросс ср":
                    x -= acceleration * 40;
                    x += grip * 2;
                    break;
                case "Лесная дорога":
                    x -= acceleration * 20;
                    x += grip * 10;
                    break;
                case "Монако узкие улицы":
                    x -= acceleration * 40;
                    x += grip * 5;
                    x -= weight;
                    break;
                case "Монако тест на перегрузки":
                    x -= acceleration * 30;
                    x += grip * 8;
                    x -= weight;
                    break;
                case "Токио тест на перегрузки":
                    x -= acceleration * 30;
                    x += grip * 8;
                    x -= weight;
                    break;
                case "Трасса для картинга":
                    x -= acceleration * 25;
                    x += grip * 10;
                    x -= weight;
                    break;
                case "Парковка":
                    x -= acceleration * 20;
                    x += grip * 10;
                    x -= weight * 2;
                    break;
                case "Лесной слалом":
                    x += grip * 10;
                    x -= weight * 3;
                    break;
                case "Закрытый картинг":
                    x -= acceleration * 10;
                    x += grip * 15;
                    x -= weight * 3;
                    break;
                case "Горы слалом":
                    x += grip * 10;
                    x -= weight * 3;
                    break;
                case "Слалом":
                    x += grip * 10;
                    x -= weight * 3;
                    break;
                case "Перегрузка":
                    x -= acceleration * 10;
                    x += grip * 15;
                    x -= weight * 2;
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