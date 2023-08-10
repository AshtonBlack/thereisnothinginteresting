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
            double traction = 0;
            switch (trackInfo.ground)
            {
                case "Асфальт":
                    if (trackInfo.weather == "Дождь")
                    {
                        if (car.drive == "4wd") traction += 100;
                        switch (car.tires)
                        {
                            case "slick":
                                traction -= 1000;
                                break;
                            case "per":
                                traction += 0;
                                break;
                            case "std":
                                traction += 300;
                                break;
                            case "all":
                                traction += 200;
                                break;
                            case "off":
                                traction -= 500;
                                break;
                        }
                    }
                    break;
                case "Гравий":
                case "Грунт":
                    switch (trackInfo.weather)
                    {
                        case "Солнечно":
                            if (car.drive == "4wd") traction += 100;
                            switch (car.tires)
                            {
                                case "slick":
                                    traction += 0;
                                    break;
                                case "per":
                                    traction += 100;
                                    break;
                                case "std":
                                    traction += 200;
                                    break;
                                case "all":
                                    traction += 300;
                                    break;
                                case "off":
                                    traction += 400;
                                    break;
                            }
                            break;
                        case "Дождь":
                            if (car.drive == "4wd") traction += 100;
                            switch (car.tires)
                            {
                                case "slick":
                                    traction -= 1000;
                                    break;
                                case "per":
                                    traction += 0;
                                    break;
                                case "std":
                                    traction += 200;
                                    break;
                                case "all":
                                    traction += 600;
                                    break;
                                case "off":
                                    traction += 800;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Песок":
                    if (car.drive == "4wd") traction += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            traction -= 200;
                            break;
                        case "per":
                            traction += 0;
                            break;
                        case "std":
                            traction += 250;
                            break;
                        case "all":
                            traction += 500;
                            break;
                        case "off":
                            traction += 800;
                            break;
                    }
                    break;
                case "Снег":                    
                case "Трава":
                case "Лед":
                    if (car.drive == "4wd") traction += 200;
                    switch (car.tires)
                    {
                        case "slick":
                            traction -= 1000;
                            break;
                        case "per":
                            traction += 0;
                            break;
                        case "std":
                            traction += 200;
                            break;
                        case "all":
                            traction += 500;
                            break;
                        case "off":
                            traction += 800;
                            break;
                    }
                    break;
            }
            double points = 0;
            switch (trackInfo.track)
            {
                case "Городские улицы у океана":
                case "Улица ср":
                case "Улица мал":
                    points -= Convert.ToDouble(car.acceleration) * 3;
                    points += Convert.ToInt16(car.grip);
                    points += traction * 2;
                    if (car.clearance != "low") points += 1000;                    
                    break;
                case "Подъем на холм":
                    points -= Convert.ToDouble(car.acceleration) * 10;
                    points += traction;
                    if (trackInfo.ground != "Асфальт")
                    {
                        switch (car.clearance)
                        {
                            case "mid":
                                points += 600;
                                break;
                            case "high":
                                points += 1000;
                                break;
                        }
                    }                    
                    break;
                case "Трасса для мотокросса":
                    points -= Convert.ToDouble(car.acceleration) * 3;
                    points += Convert.ToInt16(car.grip);
                    points += traction * 2;
                    if (car.drive == "4wd") points += 200;
                    switch (car.clearance)
                    {
                        case "mid":
                            points += 400;
                            break;
                        case "high":
                            points += 1000;
                            break;
                    }                    
                    break;
                case "50-150":
                    points -= Convert.ToDouble(car.acceleration) * 20;
                    points += Convert.ToInt16(car.speed) * 5;
                    points += traction * 0.3;
                    if (Convert.ToInt16(car.speed) < 180)
                    {
                        points -= 2000;
                    }
                    break;
                case "75-125":
                    points += traction * 0.3;
                    points -= Convert.ToDouble(car.acceleration) * 20;
                    points += Convert.ToInt16(car.speed) * 4;
                    if (Convert.ToInt16(car.speed) < 140)
                    {
                        points -= 2000;
                    }
                    break;
                case "0-60":
                case "0-100":
                case "0-100-0":
                case "1/4":
                    points += traction;
                    points -= Convert.ToDouble(car.acceleration) * 20;
                    points += Convert.ToInt16(car.speed);
                    if (Convert.ToInt16(car.speed) < 110)
                    {
                        points -= 2000;
                    }                    
                    break;
                case "1":
                    points += traction * 0.5;
                    points -= Convert.ToDouble(car.acceleration) * 10;
                    points += Convert.ToInt16(car.speed) * 3;                    
                    break;
                case "Длинная трасса у океана":
                case "Токио трасса":
                case "Трасса набережная":
                case "Короткая трасса у океана":
                case "1/2":
                    points += traction * 0.7;
                    points -= Convert.ToDouble(car.acceleration) * 15;
                    points += Convert.ToInt16(car.speed) * 2;                    
                    break;
                case "Тестовый круг":
                    points += traction * 0.2;
                    points += Convert.ToInt16(car.speed) * 5;
                    break;
                case "Нюрбург 1":
                case "Нюрбург 2":
                case "Нюрбург 3":
                case "Нюрбург 4":
                case "Нюрбург 5":
                    points += traction;
                    points += Convert.ToInt16(car.speed) * 3;
                    points -= Convert.ToDouble(car.acceleration) * 5;
                    points += Convert.ToInt16(car.grip);
                    break;
                case "Замерзшее озеро":                    
                    points -= Convert.ToDouble(car.acceleration) * 2;
                    points += Convert.ToInt16(car.grip)*2;
                    if (car.drive == "4wd") traction += 200;
                    switch (car.tires)
                    {
                        case "slick":
                            traction -= 1000;
                            break;
                        case "per":
                            traction += 0;
                            break;
                        case "std":
                            traction += 200;
                            break;
                        case "all":
                            traction += 500;
                            break;
                        case "off":
                            traction += 800;
                            break;
                    }
                    points += traction * 2;
                    break;
                case "Горы подъем на холм":
                    points += traction;
                    points -= Convert.ToDouble(car.acceleration) * 10;
                    points += Convert.ToInt16(car.grip);
                    if (trackInfo.ground != "Асфальт")
                    {
                        switch (car.clearance)
                        {
                            case "mid":
                                points += 600;
                                break;
                            case "high":
                                points += 1000;
                                break;
                        }
                    }                    
                    break;
                case "Извилистая дорога":
                    points += traction * 2;
                    points -= Convert.ToDouble(car.acceleration) * 5;
                    points += Convert.ToInt16(car.grip)*2;
                    if (trackInfo.ground != "Асфальт")
                    {
                        switch (car.clearance)
                        {
                            case "mid":
                                points += 600;
                                break;
                            case "high":
                                points += 1000;
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
                    points += traction;
                    points -= Convert.ToDouble(car.acceleration) * 5;
                    points += Convert.ToInt16(car.grip);
                    points += Convert.ToInt16(car.speed) * 2;                    
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
                    points += traction * 2;
                    points -= Convert.ToDouble(car.acceleration) * 3;
                    points += Convert.ToInt16(car.grip) * 2;
                    points += Convert.ToInt16(car.speed);
                    switch (trackInfo.ground)
                    {                        
                        case "Смешанное":
                            if (car.drive == "4wd") points += 100;
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            points += 0;
                                            break;
                                        case "per":
                                            points += 100;
                                            break;
                                        case "std":
                                            points += 150;
                                            break;
                                        case "all":
                                            points += 200;
                                            break;
                                        case "off":
                                            points += 300;
                                            break;
                                    }
                                    break;
                                case "Дождь":
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            points -= 1000;
                                            break;
                                        case "per":
                                            points -= 100;
                                            break;
                                        case "std":
                                            points += 200;
                                            break;
                                        case "all":
                                            points += 500;
                                            break;
                                        case "off":
                                            points += 100;
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case "Монако тест на перегрузки":
                case "Токио тест на перегрузки":
                case "Парковка":
                case "Лесной слалом":
                case "Закрытый картинг":
                case "Горы слалом":
                case "Слалом":
                case "Перегрузка":
                    points += traction * 3;
                    points += Convert.ToInt16(car.grip) * 5;
                    points -= Convert.ToInt16(car.weight)/10;                    
                    break;
                case "Горы серпантин":
                case "Горы извилистая дорога":
                case "Монако узкие улицы":
                case "Парковка у океана":
                case "Пляжный слалом у океана":
                case "Трасса для картинга":
                    points += traction * 3;
                    points -= Convert.ToDouble(car.acceleration);
                    points += Convert.ToInt16(car.grip) * 3;
                    points -= Convert.ToInt16(car.weight)/10;                    
                    break;
                case "Неизвестная трасса":
                    break;
                default:
                    NotePad.DoErrorLog("Написать логику для " + trackInfo.track);
                    break;
            }
            return points;
        }
    }
}