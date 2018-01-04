using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Bytes2you.Validation;
using System.Text.RegularExpressions;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                Guard.WhenArgument(value, "Cannot be null").IsNull().Throw();

                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Username must be between 2 and 20 characters long!");
                }

                var pattern = @"^[A-Za-z0-9]+$";
                if (!Regex.Match(value, pattern).Success)
                {
                    throw new ArgumentException("Username is invalid!");
                }

                //Guard.WhenArgument(value.Length, "Is not correct").IsLessThan(2).IsGreaterThan(20).Throw();
                this.username = value;
            }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }
                Guard.WhenArgument(value, "Cannot be null").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Is not correct").IsLessThan(2).IsGreaterThan(20).Throw();
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }
                Guard.WhenArgument(value, "Cannot be null").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Is not correct").IsLessThan(2).IsGreaterThan(20).Throw();
                this.lastName = value;
            }
        }
        public string Password
        {
            get { return this.password; }
            set
            {
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Password must be between 5 and 30 characters long!");
                }
                Guard.WhenArgument(value, "Cannot be null").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Is not correct").IsLessThan(2).IsGreaterThan(15).Throw();

                string pattern = "^[A-Za-z0-9@*_-]+$";
                if (!Regex.Match(value, pattern).Success)
                {
                    throw new ArgumentException("Password is invalid!");
                }
                this.password = value;
            }
        }
        public Role Role
        {
            get { return this.role; }
            set
            {
                if (!Enum.IsDefined(typeof(Role), value)) throw new ArgumentException("Invalid role type");
                this.role = value;
            }
        }
        public IList<IVehicle> Vehicles
        {
            get { return this.vehicles; }
            set
            {
                Guard.WhenArgument(value, "Cannot be null").IsNull().Throw();
                this.vehicles = value;
            }
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Guard.WhenArgument(vehicle, "Vehicle can not be null!").IsNull().Throw();

            if (this.Role != Role.Admin)
            {
                if (this.Role != Role.VIP && this.vehicles.Count == 5)
                {
                    throw new ArgumentException("You are not VIP and cannot add more than 5 vehicles!");
                }
                else
                {
                    this.Vehicles.Add(vehicle);
                }
            }
            else
            {
                throw new ArgumentException("You are an admin and cannot add vehicles!");
            }
        }
        public void RemoveVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("Vehicle does not exist!");
            }
            if (this.Vehicles.Count > 0)
            {
                this.Vehicles.Remove(vehicle);
            }
        }
        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            if (vehicleToAddComment == null)
            {
                throw new ArgumentNullException("Vehicle does not exist!");
            }

            if (commentToAdd == null)
            {
                throw new ArgumentNullException("Comment does not exist!");
            }

            vehicleToAddComment.Comments.Add(commentToAdd);
        }
        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (!vehicleToRemoveComment.Comments.Any(c => c == commentToRemove))
            {
                throw new ArgumentException("Cannot remove comment! The comment does not exist!");
            }
            if (commentToRemove.Author != Username)
            {
                throw new ArgumentException("You are not the author!");
            }
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }
        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"--USER {Username}--");

            if (!Vehicles.Any())
            {
                sb.AppendLine("--NO VEHICLES--");
                return sb.ToString().TrimEnd();
            }

            var counter = 1;

            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine($"{counter}. {vehicle.Type}:");
                sb.AppendLine($"  Make: {vehicle.Make}");
                sb.AppendLine($"  Model: {vehicle.Model}");
                sb.AppendLine($"  Wheels: {vehicle.Wheels}");
                sb.AppendLine($"  Price: ${vehicle.Price}");
                sb.AppendLine($"  {vehicle.ToString()}");

                if (vehicle.Comments.Count > 0)
                {
                    sb.AppendLine("    --COMMENTS--");
                    sb.AppendLine("    ----------  ");

                    foreach (var comment in vehicle.Comments)
                    {
                        sb.AppendLine($"    {comment.Content}");
                        sb.AppendLine($"      User: {comment.Author}");
                        sb.AppendLine("    ----------");

                        if (vehicle.Comments.Count - 1 > vehicle.Comments.IndexOf(comment))
                        {
                            sb.AppendLine("    ----------");
                        }
                    }

                    sb.AppendLine("    --COMMENTS--");
                }
                else
                {
                    sb.AppendLine("    --NO COMMENTS--");
                }

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
        public override string ToString()
        {
            return ($"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}");
        }
    }
}
