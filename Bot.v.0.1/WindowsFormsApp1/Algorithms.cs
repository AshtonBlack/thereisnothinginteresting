namespace WindowsFormsApp1 //universal
{
    public class Algorithms
    {
        public double CalculateCompatibility(string track, string coverage, string weather, Car car)
        {     
            double x = 0;
            switch (coverage)
            {
                case "Асфальт":
                    switch (weather)
                    {
                        case "Солнечно":                            
                            break;
                        case "Дождь":
                            if (car.drive == 4) x += 50;
                            switch (car.tires)
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
                    switch (car.tires)
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
                    if (car.drive == 4) x += 100;
                    break;
                case "Грунт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (car.tires)
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
                            if (car.drive == 4) x += 100;
                            break;
                        case "Дождь":
                            switch (car.tires)
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
                            if (car.drive == 4) x += 200;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Песок":
                    switch (car.tires)
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
                    if (car.drive == 4) x += 100;
                    break;
                case "Снег":
                    switch (car.tires)
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
                    if (car.drive == 4) x += 150;
                    break;
                case "Смешанное":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (car.tires)
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
                            switch (car.tires)
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
                    if (car.drive == 4) x += 200;
                    break;
                case "Трава":
                    switch (car.tires)
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
                    if (car.drive == 4) x += 150;
                    break;
                case "Лед":
                    switch (car.tires)
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
                    if (car.drive == 4) x += 150;
                    break;
            }

            switch (track)
            {
                case "Длинная трасса у океана":
                    x *= 2;
                    x -= car.acceleration * 100;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed;
                    break;
                case "Короткая трасса у океана":
                    x *= 2;
                    x -= car.acceleration * 120;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed / 2;
                    break;
                case "Магистраль у океана":
                    x *= 3;
                    x += car.maxSpeed;
                    x -= car.acceleration * 50;
                    x += car.grip;
                    break;
                case "Парковка у океана":
                case "Пляжный слалом у океана":
                    x *= 4;
                    x -= car.acceleration * 30;
                    x += car.grip * 8;
                    x -= car.weight;
                    break;
                case "Городские улицы у океана":
                case "Улица ср":
                case "Улица мал":
                    x *= 3;
                    switch (car.clearance)
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
                    x *= 3;
                    x -= car.acceleration * 50;                    
                    if (coverage != "Асфальт")
                    {
                        if (car.drive == 4) x += 100;
                        switch (car.clearance)
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
                    x *= 4;
                    if (car.drive == 4) x += 50;
                    switch (car.clearance)
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
                    x *= 1;
                    x -= car.acceleration * 100;
                    x -= car.grip;
                    x += car.weight / 10;
                    x += car.maxSpeed * 10;
                    if (car.maxSpeed < 150)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    x *= 1;
                    x -= car.acceleration * 150;
                    x -= car.grip;
                    x += car.weight / 10;
                    x += car.maxSpeed * 5;
                    if (car.maxSpeed < 130)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100":
                    x *= 3;
                    x -= car.acceleration * 200;
                    x -= car.grip*5;
                    x += car.weight / 10;
                    x += car.maxSpeed * 2;
                    if (car.maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100-0":
                    x *= 3.5;
                    x -= car.acceleration * 100;
                    x -= car.grip*5;
                    x += car.weight / 10;
                    x += car.maxSpeed * 2;
                    if (car.maxSpeed < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "1":
                    x *= 1.5;
                    x -= car.acceleration * 80;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed * 3;
                    break;
                case "1/2":
                    x *= 2.5;
                    x -= car.acceleration * 100;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed;
                    break;
                case "1/4":
                    x *= 3;
                    x -= car.acceleration * 120;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed / 2;
                    break;
                case "0-60":
                    x *= 4;
                    x -= car.acceleration * 120;
                    x -= car.grip*5;
                    x += car.weight / 10;
                    if (car.maxSpeed < 60)
                    {
                        x -= 2000;
                    }
                    break;
                case "Токио трасса":
                case "Трасса набережная":
                    x *= 2;
                    x -= car.acceleration * 100;
                    x -= car.grip * 5;
                    x += car.weight / 10;
                    x += car.maxSpeed;
                    break;
                case "Тестовый круг":
                    x *= 1;
                    x += car.maxSpeed * 5;
                    x -= car.grip*10;
                    x += car.weight / 10;
                    break;
                case "Токио мостик":
                    x *= 3;
                    x += car.maxSpeed * 3;
                    x -= car.acceleration * 6;
                    break;
                case "Нюрбург 1":
                case "Нюрбург 2":
                case "Нюрбург 3":
                case "Нюрбург 4":
                case "Нюрбург 5":
                    x *= 2.5;
                    x += car.maxSpeed * 3;
                    break;
                case "Токио петля":
                    x *= 2.5;
                    x += car.maxSpeed * 2;
                    x -= car.acceleration * 80;
                    break;
                case "Замерзшее озеро":
                    x *= 4;
                    if (car.tires == 5)
                    {
                        x += 500;
                    }
                    if (car.tires == 4)
                    {
                        x += 200;
                    }
                    break;
                case "Горы серпантин":
                    x *= 4;
                    if (coverage != "Асфальт" || weather != "Солнечно")
                    {
                        if (car.drive == 4) x += 50;
                    }                        
                    break;
                case "Горы извилистая дорога":
                    x *= 4;
                    x -= car.acceleration * 30;
                    x += car.grip * 4;
                    break;
                case "Горы дорога с уклоном":
                    x *= 3;
                    x += car.maxSpeed;
                    x -= car.acceleration * 50;
                    x += car.grip;
                    break;
                case "Горы подъем на холм":
                    x *= 3;
                    switch (car.clearance)
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
                    x -= car.acceleration * 50;
                    x += car.grip;
                    if (coverage != "Асфальт")
                    {
                        if (car.drive == 4) x += 200;
                    }                    
                    break;
                case "Горная экспедиция":
                    x *= 2.5;
                    x += car.maxSpeed;
                    x += car.grip / 2;
                    break;
                case "Извилистая дорога":
                    x *= 4;
                    if (coverage != "Асфальт")
                    {
                        switch (car.clearance)
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
                        if (car.drive == 4) x += 50;
                    }
                    break;
                case "Быстрая трасса":
                    x *= 2.5;
                    x -= car.acceleration * 40;
                    x -= car.grip / 2;
                    x += car.weight / 5;
                    x += car.maxSpeed*2;
                    break;
                case "Highway":
                    x *= 2.5;
                    x -= car.acceleration * 40;
                    x += car.weight / 5;
                    x += car.grip*2;
                    x += car.maxSpeed;
                    break;
                case "Монако длинные городские улицы":
                    x *= 3;
                    x -= car.acceleration * 40;
                    x -= car.grip / 2;
                    x += car.maxSpeed;
                    break;
                case "Каньон экспедиция":
                    x *= 2.5;
                    x -= car.acceleration * 30;
                    x -= car.grip / 4;
                    x += car.maxSpeed;
                    break;
                case "Серпантин":
                case "Монако серпантин":
                    x *= 3.5;
                    x -= car.acceleration * 50;
                    x += car.grip;
                    break;
                case "Извилистая трасса":
                    x *= 3;
                    x -= car.acceleration * 20;
                    x += car.grip*10;
                    break;
                case "Токио мост":
                case "Токио съезд":
                case "Монако городские":
                    x *= 3;
                    x += car.maxSpeed * 2;
                    x -= car.acceleration * 50;
                    x += car.grip;
                    break;
                case "Обзор":
                    x *= 2.5;
                    x += car.maxSpeed * 2;
                    x -= car.acceleration * 50;
                    x += car.grip;
                    break;
                case "Каньон грунтовая дорога":
                    x *= 2.5;
                    x -= car.acceleration * 40;
                    x += car.grip * 2;
                    break;
                case "Каньон крутой холм":
                    x *= 3;
                    x -= car.acceleration * 40;
                    x += car.grip * 2;
                    break;
                case "Лесная переправа":
                    x *= 3;
                    x -= car.acceleration * 40;
                    x += car.grip * 2;
                    break;
                case "Ралли-кросс мал":
                case "Ралли-кросс ср":
                    x *= 3;
                    x -= car.acceleration * 40;
                    x += car.grip * 2;
                    break;
                case "Лесная дорога":
                    x *= 3;
                    x -= car.acceleration * 20;
                    x += car.grip * 10;
                    break;
                case "Монако узкие улицы":
                    x *= 2.5;
                    x -= car.acceleration * 40;
                    x += car.grip * 5;
                    x -= car.weight;
                    break;
                case "Монако тест на перегрузки":
                case "Токио тест на перегрузки":
                    x *= 4.5;
                    x -= car.acceleration * 30;
                    x += car.grip * 8;
                    x -= car.weight;
                    break;
                case "Трасса для картинга":
                    x *= 4.5;
                    x -= car.acceleration * 25;
                    x += car.grip * 10;
                    x -= car.weight;
                    break;
                case "Парковка":
                    x *= 5;
                    x -= car.acceleration * 20;
                    x += car.grip * 10;
                    x -= car.weight * 2;
                    break;
                case "Лесной слалом":
                    x *= 5;
                    x += car.grip * 10;
                    x -= car.weight * 3;
                    break;
                case "Закрытый картинг":
                    x *= 5;
                    x -= car.acceleration * 10;
                    x += car.grip * 15;
                    x -= car.weight * 3;
                    break;
                case "Горы слалом":
                    x *= 4.5;
                    x += car.grip * 10;
                    x -= car.weight * 3;
                    break;
                case "Слалом":
                    x *= 5;
                    x += car.grip * 10;
                    x -= car.weight * 3;
                    break;
                case "Перегрузка":
                    x *= 5;
                    x -= car.acceleration * 10;
                    x += car.grip * 15;
                    x -= car.weight * 2;
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