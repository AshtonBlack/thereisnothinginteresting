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
            switch (trackInfo.track)
            {
                case "Городские улицы у океана":
                case "Улица ср":
                case "Улица мал":
                    x -= Convert.ToDouble(car.acceleration) * 3;
                    x += Convert.ToInt16(car.grip);
                    if (car.clearance != "low") x += 1000; 
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }                                
                            break;
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 600;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Подъем на холм":
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    if (trackInfo.ground != "Асфальт")
                    {
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
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 20;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 300;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 300;
                                        break;
                                    case "off":
                                        x += 100;
                                        break;
                                }
                            }                                
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    if (car.drive == "4wd") x += 200;
                                    if (car.drive == "rwd") x += 50;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
                                            break;
                                        case "per":
                                            x += 200;
                                            break;
                                        case "std":
                                            x += 250;
                                            break;
                                        case "all":
                                            x += 300;
                                            break;
                                        case "off":
                                            x += 350;
                                            break;
                                    }
                                    break;
                                case "Дождь":
                                    if (car.drive == "4wd") x += 300;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
                                            break;
                                        case "per":
                                            x += 400;
                                            break;
                                        case "std":
                                            x += 700;
                                            break;
                                        case "all":
                                            x += 850;
                                            break;
                                        case "off":
                                            x += 900;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Песок":
                            if (car.drive == "4wd") x += 200;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 550;
                                    break;
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 300;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 850;
                                    break;
                                case "off":
                                    x += 900;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Трасса для мотокросса":
                    x -= Convert.ToDouble(car.acceleration) * 3;
                    x += Convert.ToInt16(car.grip);
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
                    switch (trackInfo.weather)
                    {
                        case "Солнечно":
                            if (car.drive == "4wd") x += 200;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 250;
                                    break;
                                case "all":
                                    x += 300;
                                    break;
                                case "off":
                                    x += 350;
                                    break;
                            }
                            break;
                        case "Дождь":
                            if (car.drive == "4wd") x += 300;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 850;
                                    break;
                                case "off":
                                    x += 900;
                                    break;
                            }
                            break;
                    }
                    break;
                case "50-150":
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.speed) * 5;
                    if (Convert.ToInt16(car.speed) < 180)
                    {
                        x -= 2000;
                    }
                    break;
                case "75-125":
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.speed) * 4;
                    if (Convert.ToInt16(car.speed) < 140)
                    {
                        x -= 2000;
                    }
                    break;
                case "0-60":
                case "0-100":
                case "0-100-0":
                case "1/4":
                    x -= Convert.ToDouble(car.acceleration) * 20;
                    x += Convert.ToInt16(car.speed);
                    if (Convert.ToInt16(car.speed) < 110)
                    {
                        x -= 2000;
                    }
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 300;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 300;
                                    break;
                                case "off":
                                    x += 100;
                                    break;
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    if (car.drive == "4wd") x += 100;
                                    if (car.drive == "rwd") x += 50;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
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
                                case "Дождь":
                                    if (car.drive == "4wd") x += 300;
                                    if (car.drive == "rwd") x += 50;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
                                            break;
                                        case "per":
                                            x += 400;
                                            break;
                                        case "std":
                                            x += 600;
                                            break;
                                        case "all":
                                            x += 750;
                                            break;
                                        case "off":
                                            x += 800;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Песок":
                            if (car.drive == "4wd") x += 200;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 550;
                                    break;
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 300;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 850;
                                    break;
                                case "off":
                                    x += 900;
                                    break;
                            }
                            break;
                        case "Трава":
                        case "Лед":
                            if (car.drive == "4wd") x += 300;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 950;
                                    break;
                                case "off":
                                    x += 1100;
                                    break;
                            }
                            break;
                    }
                    break;
                case "1":
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.speed) * 3; 
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 300;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 300;
                                        break;
                                    case "off":
                                        x += 100;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    if (car.drive == "4wd") x += 50;
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
                                            x += 100;
                                            break;
                                        case "off":
                                            x += 100;
                                            break;
                                    }
                                    break;
                                case "Дождь":
                                    if (car.drive == "4wd") x += 200;
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
                                            x += 550;
                                            break;
                                        case "off":
                                            x += 600;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Песок":
                            if (car.drive == "4wd") x += 200;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 550;
                                    break;
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 200;
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
                                    x += 550;
                                    break;
                                case "off":
                                    x += 600;
                                    break;
                            }
                            break;
                        case "Трава":
                        case "Лед":
                            if (car.drive == "4wd") x += 300;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 900;
                                    break;
                                case "off":
                                    x += 1000;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Длинная трасса у океана":
                case "Токио трасса":
                case "Трасса набережная":
                case "Короткая трасса у океана":
                case "1/2":
                    x -= Convert.ToDouble(car.acceleration) * 15;
                    x += Convert.ToInt16(car.speed) * 2;
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 300;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 300;
                                        break;
                                    case "off":
                                        x += 100;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    if (car.drive == "4wd") x += 50;
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
                                            x += 100;
                                            break;
                                        case "off":
                                            x += 100;
                                            break;
                                    }
                                    break;
                                case "Дождь":
                                    if (car.drive == "4wd") x += 200;
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
                                            x += 550;
                                            break;
                                        case "off":
                                            x += 600;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Песок":
                            if (car.drive == "4wd") x += 200;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 550;
                                    break;
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 200;
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
                                    x += 600;
                                    break;
                                case "off":
                                    x += 800;
                                    break;
                            }
                            break;
                        case "Трава":
                        case "Лед":
                            if (car.drive == "4wd") x += 300;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 900;
                                    break;
                                case "off":
                                    x += 1000;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Тестовый круг":
                    x += Convert.ToInt16(car.speed) * 5;
                    if (trackInfo.ground != "Асфальт" || trackInfo.weather == "Дождь")
                    {
                        switch (car.tires)
                        {
                            case "slick":
                                x += 0;
                                break;
                            case "per":
                                x += 300;
                                break;
                            case "std":
                                x += 300;
                                break;
                            case "all":
                                x += 300;
                                break;
                            case "off":
                                x += 100;
                                break;
                        }
                    }
                    break;
                case "Нюрбург 1":
                case "Нюрбург 2":
                case "Нюрбург 3":
                case "Нюрбург 4":
                case "Нюрбург 5":
                    x += Convert.ToInt16(car.speed) * 3;
                    x -= Convert.ToDouble(car.acceleration) * 5;
                    x += Convert.ToInt16(car.grip);
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 20;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 200;
                                        break;
                                    case "all":
                                        x += 150;
                                        break;
                                    case "off":
                                        x += 50;
                                        break;
                                }
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 200;
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
                                    x += 600;
                                    break;
                                case "off":
                                    x += 800;
                                    break;
                            }
                            break;
                        case "Лед":
                            if (car.drive == "4wd") x += 300;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 900;
                                    break;
                                case "off":
                                    x += 1000;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Замерзшее озеро":
                    x -= Convert.ToDouble(car.acceleration) * 2;
                    x += Convert.ToInt16(car.grip)*2;
                    if (car.drive == "4wd") x += 100;
                    switch (car.tires)
                    {
                        case "slick":
                            x += 0;
                            break;
                        case "per":
                            x += 250;
                            break;
                        case "std":
                            x += 400;
                            break;
                        case "all":
                            x += 600;
                            break;
                        case "off":
                            x += 800;
                            break;
                    }
                    break;
                case "Горы подъем на холм":   
                    x -= Convert.ToDouble(car.acceleration) * 10;
                    x += Convert.ToInt16(car.grip);
                    if (trackInfo.ground != "Асфальт")
                    {
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
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 20;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 300;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 300;
                                        break;
                                    case "off":
                                        x += 100;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
                                    if (car.drive == "4wd") x += 200;
                                    if (car.drive == "rwd") x += 50;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
                                            break;
                                        case "per":
                                            x += 200;
                                            break;
                                        case "std":
                                            x += 250;
                                            break;
                                        case "all":
                                            x += 300;
                                            break;
                                        case "off":
                                            x += 350;
                                            break;
                                    }
                                    break;
                                case "Дождь":
                                    if (car.drive == "4wd") x += 300;
                                    switch (car.tires)
                                    {
                                        case "slick":
                                            x += 0;
                                            break;
                                        case "per":
                                            x += 400;
                                            break;
                                        case "std":
                                            x += 700;
                                            break;
                                        case "all":
                                            x += 850;
                                            break;
                                        case "off":
                                            x += 900;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Песок":
                            if (car.drive == "4wd") x += 200;
                            if (car.drive == "rwd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 200;
                                    break;
                                case "std":
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 550;
                                    break;
                            }
                            break;
                        case "Снег":
                            if (car.drive == "4wd") x += 300;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 400;
                                    break;
                                case "std":
                                    x += 700;
                                    break;
                                case "all":
                                    x += 850;
                                    break;
                                case "off":
                                    x += 900;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Извилистая дорога":
                    x -= Convert.ToDouble(car.acceleration) * 5;
                    x += Convert.ToInt16(car.grip)*2;
                    if (trackInfo.ground != "Асфальт")
                    {
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
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
                                    break;
                                case "off":
                                    x += 600;
                                    break;
                            }
                            break;
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
                    x -= Convert.ToDouble(car.acceleration) * 5;
                    x += Convert.ToInt16(car.grip);
                    x += Convert.ToInt16(car.speed) * 2;
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
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
                    }
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
                    x -= Convert.ToDouble(car.acceleration) * 3;
                    x += Convert.ToInt16(car.grip) * 2;
                    x += Convert.ToInt16(car.speed);
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 450;
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
                    x += Convert.ToInt16(car.grip) * 5;
                    x -= Convert.ToInt16(car.weight)/10;
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 500;
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
                    }
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
                    switch (trackInfo.ground)
                    {
                        case "Асфальт":
                            if (trackInfo.weather == "Дождь")
                            {
                                if (car.drive == "4wd") x += 50;
                                switch (car.tires)
                                {
                                    case "slick":
                                        x += 0;
                                        break;
                                    case "per":
                                        x += 180;
                                        break;
                                    case "std":
                                        x += 300;
                                        break;
                                    case "all":
                                        x += 200;
                                        break;
                                    case "off":
                                        x += 70;
                                        break;
                                }
                            }
                            break;
                        case "Гравий":
                        case "Грунт":
                            switch (trackInfo.weather)
                            {
                                case "Солнечно":
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
                                            x += 200;
                                            break;
                                        case "all":
                                            x += 300;
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
                                            x += 150;
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
                                    x += 130;
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
                        case "Снег":
                            if (car.drive == "4wd") x += 50;
                            switch (car.tires)
                            {
                                case "slick":
                                    x += 0;
                                    break;
                                case "per":
                                    x += 150;
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
                        case "Трава":
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
                                    x += 300;
                                    break;
                                case "all":
                                    x += 500;
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
                    }
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