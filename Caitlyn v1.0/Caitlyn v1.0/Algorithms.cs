using System;

namespace Caitlyn_v1._0
{
    public class Algorithms
    {        
        public int CalculatePoints(CarForExcel car, TrackInfo trackInfo)
        {            
            return (int)CalculateCompatibility(car, trackInfo);
        }
        public double CalculateCompatibility(CarForExcel car, TrackInfo trackInfo)
        {
            double x = 0;
            switch (trackInfo.ground)
            {
                case "Асфальт":
                    if(trackInfo.weather == "Дождь")
                        if (car.drive == "4wd") x += 50;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 100;
                            break;
                        case "std":
                            x += 300;
                            break;
                        case "all":
                            x += 150;
                            break;
                        case "off":
                            x += 30;
                            break;
                    }
                    break;
                case "Гравий":                    
                    if (car.drive == "4wd") x += 200;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 50;
                            break;
                        case "per":
                            x += 100;
                            break;
                        case "std":
                            x += 150;
                            break;
                        case "all":
                            x += 200;
                            break;
                        case "off":
                            x += 200;
                            break;
                    }
                    break;
                case "Грунт":
                    switch (trackInfo.weather)
                    {
                        case "Солнечно":
                            if (car.drive == "4wd") x += 100;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 50;
                                    break;
                                case "std":
                                    x += 100;
                                    break;
                                case "all":
                                    x += 200;
                                    break;
                                case "off":
                                    x += 400;
                                    break;
                            }
                            break;
                        case "Дождь":
                            if (car.drive == "4wd") x += 100;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 100;
                                    break;
                                case "std":
                                    x += 200;
                                    break;
                                case "all":
                                    x += 400;
                                    break;
                                case "off":
                                    x += 600;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Песок":
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 100;
                            break;
                        case "std":
                            x += 200;
                            break;
                        case "all":
                            x += 400;
                            break;
                        case "off":
                            x += 600;
                            break;
                    }
                    break;
                case "Снег":
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 100;
                            break;
                        case "std":
                            x += 200;
                            break;
                        case "all":
                            x += 400;
                            break;
                        case "off":
                            x += 600;
                            break;
                    }
                    break;
                case "Смешанное":
                    if (car.drive == "4wd") x += 100;
                    switch (trackInfo.weather)
                    {
                        case "Солнечно":
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 50;
                                    break;
                                case "std":
                                    x += 50;
                                    break;
                                case "all":
                                    x += 100;
                                    break;
                                case "off":
                                    x += 150;
                                    break;
                            }
                            break;
                        case "Дождь":
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
                                    break;
                                case "std":
                                    x += 250;
                                    break;
                                case "all":
                                    x += 300;
                                    break;
                                case "off":
                                    x += 150;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Трава":
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 150;
                            break;
                        case "std":
                            x += 250;
                            break;
                        case "all":
                            x += 400;
                            break;
                        case "off":
                            x += 600;
                            break;
                    }
                    break;
                case "Лед":
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 150;
                            break;
                        case "std":
                            x += 250;
                            break;
                        case "all":
                            x += 400;
                            break;
                        case "off":
                            x += 600;
                            break;
                    }
                    break;
            }
            switch (trackInfo.track)
            {
                case "Длинная трасса у океана":
                    x *= 2;
                    x -= Convert.ToDouble(car.acceleration) * 100;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Короткая трасса у океана":
                    x *= 2;
                    x -= Convert.ToDouble(car.acceleration) * 120;
                    x += Convert.ToInt16(car.speed) / 2;
                    break;
                case "Магистраль у океана":
                    x *= 3;
                    x += Convert.ToInt16(car.speed);
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    break;
                case "Парковка у океана":
                case "Пляжный слалом у океана":
                    x *= 4;
                    x -= Convert.ToDouble(car.acceleration) * 30;
                    x += Convert.ToInt16(car.grip) * 8;
                    x -= Convert.ToInt16(car.weight);
                    break;
                case "Городские улицы у океана":
                case "Улица ср":
                case "Улица мал":
                    x *= 3;
                    if(car.clearance != "low") x += 1000;
                    break;
                case "Подъем на холм":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    if (trackInfo.ground != "Асфальт")
                    {
                        if (car.drive == "4wd") x += 200;
                        switch (car.clearance)
                        {
                            case "mid":
                                x += 600;
                                break;
                            case "high":
                                x += 1000;
                                break;
                        }
                    }
                    break;
                case "Трасса для мотокросса":
                    x *= 4;
                    if (car.drive == "4wd") x += 200;
                    switch (car.clearance)
                    {
                        case "mid":
                            x += 400;
                            break;
                        case "high":
                            x += 1000;
                            break;
                    }
                    break;
                case "50-150":
                    x *= 1;
                    x -= Convert.ToDouble(car.acceleration) * 100;
                    x += Convert.ToInt16(car.speed) * 10;
                    if (Convert.ToInt16(car.speed) < 150)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    x *= 1;
                    x -= Convert.ToDouble(car.acceleration) * 150;
                    x += Convert.ToInt16(car.speed) * 5;
                    if (Convert.ToInt16(car.speed) < 130)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 200;
                    x += Convert.ToInt16(car.speed) * 2;
                    if (Convert.ToInt16(car.speed) < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-100-0":
                    x *= 3.5;
                    x -= Convert.ToDouble(car.acceleration) * 100;
                    x += Convert.ToInt16(car.speed) * 2;
                    if (Convert.ToInt16(car.speed) < 105)
                    {
                        x -= 2000;
                    }
                    break;
                case "1":
                    x *= 1.5;
                    x -= Convert.ToDouble(car.acceleration) * 80;
                    x += Convert.ToInt16(car.speed) * 3;
                    break;
                case "1/2":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 100;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "1/4":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 120;
                    x += Convert.ToInt16(car.speed) / 2;
                    break;
                case "0-60":
                    x *= 4;
                    x -= Convert.ToDouble(car.acceleration) * 120;
                    if (Convert.ToInt16(car.speed) < 60)
                    {
                        x -= 2000;
                    }
                    break;
                case "Токио трасса":
                case "Трасса набережная":
                    x *= 2;
                    x -= Convert.ToDouble(car.acceleration) * 100;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Тестовый круг":
                    x *= 1;
                    x += Convert.ToInt16(car.speed) * 5;
                    break;
                case "Токио мостик":
                    x *= 3;
                    x += Convert.ToInt16(car.speed) * 3;
                    x -= Convert.ToDouble(car.acceleration) * 6;
                    break;
                case "Нюрбург 1":
                case "Нюрбург 2":
                case "Нюрбург 3":
                case "Нюрбург 4":
                case "Нюрбург 5":
                    x *= 2.5;
                    x += Convert.ToInt16(car.speed) * 3;
                    break;
                case "Токио петля":
                    x *= 2.5;
                    x += Convert.ToInt16(car.speed) * 2;
                    x -= Convert.ToDouble(car.acceleration) * 80;
                    break;
                case "Замерзшее озеро":
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 150;
                            break;
                        case "std":
                            x += 250;
                            break;
                        case "all":
                            x += 400;
                            break;
                        case "off":
                            x += 600;
                            break;
                    }
                    break;
                case "Горы серпантин":
                    x *= 4;
                    if (trackInfo.ground != "Асфальт" || trackInfo.weather != "Солнечно")
                    {
                        if (car.drive == "4wd") x += 50;
                    }
                    break;
                case "Горы извилистая дорога":
                    x *= 4;
                    x -= Convert.ToDouble(car.acceleration) * 30;
                    x += Convert.ToInt16(car.grip) * 4;
                    break;
                case "Горы дорога с уклоном":
                    x *= 3;
                    x += Convert.ToInt16(car.speed);
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    break;
                case "Горы подъем на холм":
                    x *= 3;                    
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    if (trackInfo.ground != "Асфальт")
                    {
                        if (car.drive == "4wd") x += 200;
                        switch (car.clearance)
                        {
                            case "mid":
                                x += 600;
                                break;
                            case "high":
                                x += 1000;
                                break;
                        }
                    }
                    break;
                case "Горная экспедиция":
                    x *= 2.5;
                    x += Convert.ToInt16(car.speed);
                    x += Convert.ToInt16(car.grip) / 2;
                    break;
                case "Извилистая дорога":
                    x *= 4;
                    if (trackInfo.ground != "Асфальт")
                    {
                        if (car.drive == "4wd") x += 100;
                        switch (car.clearance)
                        {
                            case "mid":
                                x += 600;
                                break;
                            case "high":
                                x += 1000;
                                break;
                        }
                    }
                    break;
                case "Быстрая трасса":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 40;;
                    x += Convert.ToInt16(car.speed) * 2;
                    break;
                case "Highway":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 2;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Монако длинные городские улицы":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Каньон экспедиция":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 30;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Серпантин":
                case "Монако серпантин":
                    x *= 3.5;
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    break;
                case "Извилистая трасса":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.grip) * 10;
                    break;
                case "Токио мост":
                case "Токио съезд":
                case "Монако городские":
                    x *= 3;
                    x += Convert.ToInt16(car.speed) * 2;
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    break;
                case "Обзор":
                    x *= 2.5;
                    x += Convert.ToInt16(car.speed) * 2;
                    x -= Convert.ToDouble(car.acceleration) * 50;
                    x += Convert.ToInt16(car.grip);
                    break;
                case "Каньон грунтовая дорога":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 2;
                    break;
                case "Каньон крутой холм":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 2;
                    break;
                case "Лесная переправа":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 2;
                    break;
                case "Ралли-кросс мал":
                case "Ралли-кросс ср":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 2;
                    break;
                case "Лесная дорога":
                    x *= 3;
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.grip) * 10;
                    break;
                case "Монако узкие улицы":
                    x *= 2.5;
                    x -= Convert.ToDouble(car.acceleration) * 40;
                    x += Convert.ToInt16(car.grip) * 5;
                    x -= Convert.ToInt16(car.weight);
                    break;
                case "Монако тест на перегрузки":
                case "Токио тест на перегрузки":
                    x *= 4.5;
                    x -= Convert.ToDouble(car.acceleration) * 30;
                    x += Convert.ToInt16(car.grip) * 8;
                    x -= Convert.ToInt16(car.weight);
                    break;
                case "Трасса для картинга":
                    x *= 4.5;
                    x -= Convert.ToDouble(car.acceleration) * 25;
                    x += Convert.ToInt16(car.grip) * 10;
                    x -= Convert.ToInt16(car.weight);
                    break;
                case "Парковка":
                    x *= 5;
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.grip) * 10;
                    x -= Convert.ToInt16(car.weight) * 2;
                    break;
                case "Лесной слалом":
                    x *= 5;
                    x += Convert.ToInt16(car.grip) * 10;
                    x -= Convert.ToInt16(car.weight) * 3;
                    break;
                case "Закрытый картинг":
                    x *= 5;
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.grip) * 15;
                    x -= Convert.ToInt16(car.weight) * 3;
                    break;
                case "Горы слалом":
                    x *= 4.5;
                    x += Convert.ToInt16(car.grip) * 10;
                    x -= Convert.ToInt16(car.weight) * 3;
                    break;
                case "Слалом":
                    x *= 5;
                    x += Convert.ToInt16(car.grip) * 10;
                    x -= Convert.ToInt16(car.weight) * 3;
                    break;
                case "Перегрузка":
                    x *= 5;
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.grip) * 15;
                    x -= Convert.ToInt16(car.weight) * 2;
                    break;
                case "Неизвестная трасса":
                    break;
                default:
                    NotePad.DoErrorLog("Написать логику для " + trackInfo.track);
                    break;
            }
            return x;
        }
    }
}
