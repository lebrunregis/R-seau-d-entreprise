using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolBox.DBTools
{
    public class Command
    {
        public string Query { get; set; }
        public bool IsStoredProcedure { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, ParamDirection> ParamDirections { get; set; }
        public Command(string Command) : this(Command, false)
        {
        }
        public Command(string command, bool isStoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new FormatException("Commande invalide!");
            }
            else
            {
                Query = command;
                IsStoredProcedure = isStoredProcedure;
                Parameters = new Dictionary<string, object>();
                ParamDirections = new Dictionary<string, ParamDirection>();
            }
        }
        public void AddParameter(string arg, object val)
        {
            Parameters.Add(arg, val ?? DBNull.Value);
            ParamDirections.Add(arg, ParamDirection.Input);
        }
        public void AddParameter(string arg, object val ,ParamDirection direction)
        {
            Parameters.Add(arg, val ?? DBNull.Value);
            ParamDirections.Add(arg, direction);
        }
    }
}
