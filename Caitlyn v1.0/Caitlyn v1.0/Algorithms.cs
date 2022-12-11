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
                            x += 300;
                            break;
                        case "std":
                            x += 500;
                            break;
                        case "all":
                            x += 350;
                            break;
                        case "off":
                            x += 50;
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
                case "Городские улицы у океана":
                case "Улица ср":
                case "Улица мал":
                    if(car.clearance != "low") x += 1000;
                    break;
                case "Подъем на холм":
                    x -= Convert.ToDouble(car.acceleration) * 5;
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
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.speed) * 5;
                    if (Convert.ToInt16(car.speed) < 150)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.speed) * 4;
                    if (Convert.ToInt16(car.speed) < 130)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-60":
                case "0-100":
                case "0-100-0":
                case "1/4":
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.speed) * 2;
                    if (Convert.ToInt16(car.speed) < 110)
                    {
                        x -= 2000;
                    }
                    break;
                case "1":
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.speed) * 3;
                    break;
                case "Длинная трасса у океана":
                case "Токио трасса":
                case "Трасса набережная":
                case "Короткая трасса у океана":
                case "1/2":
                    x -= Convert.ToDouble(car.acceleration) * 5;
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Тестовый круг":
                    x += Convert.ToInt16(car.speed) * 5;
                    break;
                case "Нюрбург 1":
                case "Нюрбург 2":
                case "Нюрбург 3":
                case "Нюрбург 4":
                case "Нюрбург 5":
                    x += Convert.ToInt16(car.speed) * 3;
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
                case "Горы подъем на холм":   
                    x -= Convert.ToDouble(car.acceleration) * 5;
                    x += Convert.ToInt16(car.grip)/2;
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
                case "Извилистая дорога":
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
                case "Горы дорога с уклоном":
                case "Горная экспедиция":
                case "Магистраль у океана":
                case "Токио мостик":
                case "Обзор":                
                case "Токио мост":
                case "Токио съезд":
                case "Монако городские":
                case "Каньон экспедиция":
                case "Быстрая трасса":
                case "Highway":
                    x -= Convert.ToDouble(car.acceleration) * 3;
                    x += Convert.ToInt16(car.grip);
                    x += Convert.ToInt16(car.speed);
                    break;
                case "Токио петля":
                case "Серпантин":
                case "Монако серпантин":
                case "Монако длинные городские улицы":
                case "Извилистая трасса":
                case "Лесная дорога":
                case "Лесная переправа":
                case "Каньон грунтовая дорога":
                case "Каньон крутой холм":                    
                case "Ралли-кросс мал":
                case "Ралли-кросс ср":
                    x -= Convert.ToDouble(car.acceleration) * 2;
                    x += Convert.ToInt16(car.grip) * 2;
                    break;
                case "Монако тест на перегрузки":
                case "Токио тест на перегрузки":
                case "Парковка":
                case "Лесной слалом":
                case "Закрытый картинг":
                case "Горы слалом":
                case "Слалом":
                case "Перегрузка":
                    x += Convert.ToInt16(car.grip) * 5;
                    x -= Convert.ToInt16(car.weight)/10;
                    break;
                case "Горы серпантин":
                case "Горы извилистая дорога":
                case "Монако узкие улицы":
                case "Парковка у океана":
                case "Пляжный слалом у океана":
                case "Трасса для картинга":
                    x -= Convert.ToDouble(car.acceleration);
                    x += Convert.ToInt16(car.grip) * 3;
                    x -= Convert.ToInt16(car.weight)/10;
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
