﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Application.Utilities
{
    public static class UtilityManager
    {
        public static string GenerateSecurityStamp()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32]; // 256 bits
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
        public static bool IsMobile(string input)
        {
            string mobilePattern = @"^09\d{9}$";
            return Regex.IsMatch(input, mobilePattern);
        }
        public static bool IsMail(string input)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(input, emailPattern);
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName() ?? enumValue.ToString();
        }
        public static bool IsValidNationalCode(string input)
        {
            string pattern = @"^[0-9]{10}$";
            return Regex.IsMatch(input, pattern);
        }
        public static string OtpGenrator()
        {
            int length = 6;
            const string allowedChars = "0123456789";

            Random random = new Random();

            StringBuilder otpBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, allowedChars.Length);

                otpBuilder.Append(allowedChars[index]);
            }

            return otpBuilder.ToString();
        }

        public static Guid GetCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Guid.Empty;
            }
            var user = httpContextAccessor.HttpContext.User;
            return Guid.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public static string EntityChanges<T>(T firstOne, T secondOne)
        {
            if (firstOne == null || secondOne == null)
            {
                throw new ArgumentNullException("Both entities must be non-null.");
            }

            Type entityType = typeof(T);
            PropertyInfo[] properties = entityType.GetProperties();
            StringBuilder changes = new StringBuilder();

            foreach (var property in properties)
            {
                var firstValue = property.GetValue(firstOne);
                var secondValue = property.GetValue(secondOne);

                if (!Equals(firstValue, secondValue))
                {
                    changes.AppendLine($"{property.Name} changed from '{firstValue}' to '{secondValue}'");
                }
            }

            return changes.Length > 0 ? changes.ToString() : "No changes detected.";
        }

        public static string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }

        public static string ConvertGregorianDateTimeToPersianDate(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(date);
            int month = persianCalendar.GetMonth(date);
            int day = persianCalendar.GetDayOfMonth(date);

            // Format the date as "yyyy/MM/dd"
            return $"{year:0000}/{month:00}/{day:00} ";
        }

        public static string GregorianDateTimeToPersianDate(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(date);
            int month = persianCalendar.GetMonth(date);
            int day = persianCalendar.GetDayOfMonth(date);
            int hour = persianCalendar.GetHour(date);
            int minute = persianCalendar.GetMinute(date);
            int second = persianCalendar.GetSecond(date);

            // Format the date as "yyyy/MM/dd HH:mm:ss"
            return $"{year:0000}/{month:00}/{day:00} {hour:00}:{minute:00}:{second:00}";
        }
        public static string GregorianDateTimeToPersianDateOnly(DateOnly date)
        {
            // Convert DateOnly to DateTime using midnight time
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Unspecified);

            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            // Format the date as "yyyy/MM/dd"
            return $"{year:0000}/{month:00}/{day:00}";
        }


        public static string GregorianDateTimeToPersianDateDashType(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(date);
            int month = persianCalendar.GetMonth(date);
            int day = persianCalendar.GetDayOfMonth(date);
            int hour = persianCalendar.GetHour(date);
            int minute = persianCalendar.GetMinute(date);
            int second = persianCalendar.GetSecond(date);

            // Format the date as "yyyy/MM/dd HH:mm:ss"
            return $"{year:0000}-{month:00}";
        }

        public static DateTime GetLastDayOfPersianMonth(int year, int month)
        {
            // Define the Persian calendar
            PersianCalendar persianCalendar = new PersianCalendar();

            // Determine the last day of the month
            int lastDay;
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
            }

            if (month <= 6)
            {
                lastDay = 31;
            }
            else if (month <= 11)
            {
                lastDay = 30;
            }
            else
            {
                // The last month (Esfand) can be 29 or 30 days depending on whether it's a leap year
                lastDay = persianCalendar.IsLeapYear(year) ? 30 : 29;
            }

            // Convert the Persian date to Gregorian date
            DateTime lastDayOfMonth = persianCalendar.ToDateTime(year, month, lastDay, 0, 0, 0, 0);

            return lastDayOfMonth;
        }

        public static DateTime ConvertPersianToGregorian(string persianDate)
        {
            string[] parts = persianDate.Split('-');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            PersianCalendar pc = new PersianCalendar();
            DateTime gregorianDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

            return gregorianDate;
        }

        private static readonly string[] PersianMonthNames =
        {
        "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
        "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        private static readonly string[] PersianDayOfWeekNames =
        {
            "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه"
        };


    }
}
