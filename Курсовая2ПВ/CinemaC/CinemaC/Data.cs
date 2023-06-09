﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal static class Data
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=CinemaSystem;Integrated Security=true";

        public static List<Ticket> Tickets = new List<Ticket>();
        public static List<Session> Sessions = new List<Session>();
        public static List<Movie> Movies = new List<Movie>();
        public static List<Hall> Halls = new List<Hall>();
        public static List<Price> Prices = new List<Price>();
        public static List<SeatCategory> SeatCategories = new List<SeatCategory>();
        public static List<SeatAndRow> SeatsAndRows = new List<SeatAndRow>();

        public static List<decimal> money = new List<decimal>() { 6.5m, 7.5m, 8.9m };

        public static void Initialization()
        {
            GetSeatsAndRowsFromDB();
            GetSeatCategoriesFromDB();
            GetPricesFromDB();
            GetHallsFromDB();
            GetMoviesFromDB();
            GetSessionsFromDB();
            GetTicketsFromDB();
        }

        public static void DelPrice(Price p)
        {
            Prices.Remove(p);
            try
            {
                string sqlExpression = $"DELETE FROM Prices WHERE " +
                    $"Date = '{p.Date}' AND Time = '{p.Time}' AND Hall = '{p.Category}' " +
                    $"AND Price = '{p.Money}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddMoney(Price p)
        {
            Prices.Add(p);
            try
            {
                string sqlExpression = $"INSERT INTO Prices (Date, Time, Hall, Price) VALUES " +
                    $"('{p.Date}', '{p.Time}', '{p.Category}', '{p.Money}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditSession(Session oldss, Session newss)
        {
            Sessions[Sessions.IndexOf(oldss)] = newss;
            try
            {
                string sqlExpression = $"UPDATE Sessions SET " +
                    $"Date = '{newss.Date}', Time = '{newss.Time}', Hall = '{newss.Hall}', Movie = '{newss.Movie}' WHERE " +
                    $"Date = '{oldss.Date}' AND Time = '{oldss.Time}' AND Hall = '{oldss.Hall}' AND Movie = '{oldss.Movie}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditTicket(Ticket oldtk, Ticket newtk)
        {
            Tickets[Tickets.IndexOf(oldtk)] = newtk;
            try
            {
                string sqlExpression = $"UPDATE Tickets SET " +
                    $"Date = '{newtk.Date}', Time = '{newtk.Time}', Hall = '{newtk.Hall}', Row = '{newtk.Row}', Place = '{newtk.Place}', Sold = '{newtk.Sold}' WHERE " +
                    $"Date = '{oldtk.Date}' AND Time = '{oldtk.Time}' AND Hall = '{oldtk.Hall}' AND Row = '{oldtk.Row}' AND Place = '{oldtk.Place}' AND Sold = '{oldtk.Sold}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditMovie(Movie oldmv, Movie newmv)
        {
            Movies[Movies.IndexOf(oldmv)] = newmv;
            try
            {
                MessageBox.Show(Convert.ToString(newmv.NameMovie) + "\n" + Convert.ToString(oldmv.NameMovie), "");
                string sqlExpression = $"UPDATE Movies SET " +
                    $"NameMovie = '{newmv.NameMovie}', Country = '{newmv.Country}', YearOfIssue = '{newmv.YearOfIssue}', Genre = '{newmv.Genre}', Duration = '{newmv.Duration}' WHERE " +
                    $"NameMovie = '{oldmv.NameMovie}' AND Country = '{oldmv.Country}' AND YearOfIssue = '{oldmv.YearOfIssue}' AND Genre = '{oldmv.Genre}' AND Duration = '{oldmv.Duration}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void DelSession(Session ss)
        {
            Sessions.Remove(ss);
            try
            {
                MessageBox.Show(Convert.ToString(ss.Movie), "");
                string sqlExpression = $"DELETE FROM Sessions WHERE " +
                    $"Date = '{ss.Date}' AND Time = '{ss.Time}' AND Hall = '{ss.Hall}' " +
                    $"AND Movie = '{ss.Movie}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddSession(Session ss)
        {
            Sessions.Add(ss);
            try
            {
                string sqlExpression = $"INSERT INTO Sessions (Date, Time, Hall, Movie) VALUES " +
                    $"('{ss.Date}', '{ss.Time}', '{ss.Hall}', '{ss.Movie}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void DelTicket(Ticket tk)
        {
            Tickets.Remove(tk);
            try
            {
                string sqlExpression = $"DELETE FROM Tickets WHERE " +
                    $"Date = '{tk.Date}' AND Time = '{tk.Time}' AND Hall = '{tk.Hall}' " +
                    $"AND Row = '{tk.Row+1}' AND Place = '{tk.Place+1}' AND Sold = '{Convert.ToInt32(tk.Sold)}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddTicket(Ticket tk)
        {
            Tickets.Add(tk);
            try
            {
                string sqlExpression = $"INSERT INTO Tickets (Date, Time, Hall, Row, Place, Sold) VALUES " +
                    $"('{tk.Date}', '{tk.Time}', '{tk.Hall}', '{tk.Row}', '{tk.Place}', '{tk.Sold}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static int GetTicketID(Ticket t)
        {
            int tID = -1;
            try
            {
                string sqlExpression = $"SELECT IDticket FROM Tickets WHERE " +
                    $"Date = '{t.Date}' AND Time = '{t.Time}' AND Hall = '{t.Hall}' " +
                    $"AND Row = '{t.Row}' AND Place = '{t.Place}' AND Sold = '{t.Sold}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        tID = reader.GetInt32(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }

            return tID;
        }

        public static void DelMovie(Movie mv)
        {
            Movies.Remove(mv);
            try
            {
                string sqlExpression = $"DELETE FROM Movies WHERE " +
                    $"NameMovie = '{mv.NameMovie}' AND Country = '{mv.Country}' AND YearOfIssue = '{mv.YearOfIssue}' " +
                    $"AND Genre = '{mv.Genre}' AND Duration = '{mv.Duration}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddMovie(Movie mv)
        {
            Movies.Add(mv);
            try
            {
                string sqlExpression = $"INSERT INTO Movies (NameMovie, Country, YearOfIssue, Genre, Duration) VALUES " +
                    $"('{mv.NameMovie}', '{mv.Country}', '{mv.YearOfIssue}', '{mv.Genre}', '{mv.Duration}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetSeatsAndRowsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Seatsandrows";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    SeatsAndRows.Clear();

                    while (reader.Read())
                    {
                        SeatsAndRows.Add(new SeatAndRow(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetSeatCategoriesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Seatcategories";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    SeatCategories.Clear();

                    while (reader.Read())
                    {
                        SeatCategories.Add(new SeatCategory(reader.GetInt32(0)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetPricesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Prices";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Prices.Clear();

                    while (reader.Read())
                    {
                        Prices.Add(new Price(reader.GetDateTime(0), reader.GetTimeSpan(1), reader.GetInt32(2), reader.GetDecimal(3)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetHallsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Halls";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Halls.Clear();

                    while (reader.Read())
                    {
                        Halls.Add(new Hall(reader.GetInt32(0), reader.GetString(1)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetMoviesFromDB()
        {
            try
            {
                string query = "SELECT * FROM Movies";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Movies.Clear();

                    while (reader.Read())
                    {
                        Movies.Add(new Movie(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetSessionsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Sessions";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Sessions.Clear();

                    while (reader.Read())
                    {
                        Sessions.Add(new Session(reader.GetDateTime(0), reader.GetTimeSpan(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch(SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetTicketsFromDB()
        {
            try
            {
                string query = "SELECT * FROM Tickets";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Tickets.Clear();

                    while(reader.Read())
                    {
                        Tickets.Add(new Ticket(reader.GetDateTime(1), reader.GetTimeSpan(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetBoolean(6)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

    }
}
