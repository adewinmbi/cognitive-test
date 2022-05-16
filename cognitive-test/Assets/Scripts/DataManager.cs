using System.Collections.Generic;

public static class DataManager {

    public class PersonData {
        public string Name { get; set; }
        public List<float> ReactionTimes { get; set; }
        public List<bool> ReactionCorrect { get; set; }
        public List<float> ConcentrationTimes { get; set; }
    }

    public static List<float> concentrationTimes;

    /// <summary>
    /// Writes the data stored in the PersonData class into a csv file.
    /// </summary>
    public static void LogData(PersonData personData) {
        string csv = "";

        // Add header
        csv += "Test Index,Reaction Time,Reaction Correct,Concentration Time\n";

        // Append data
        for (int i = 0; i < personData.ReactionTimes.Count; i++) { // Reaction times and concentration times list should be the same length.
            csv += i.ToString() + "," + personData.ReactionTimes[i].ToString() + "," + personData.ConcentrationTimes[i].ToString() + "\n";
        }

        // TODO: Write to text file
    }

    public static string FloatListToString(string title, List<float> list) {
        string returnString = title + ": ";

        int index = 0;
        for (int i = 0; i < list.Count - 1; i++) {
            returnString += list[i].ToString() + ", ";
            index = i;
        }
        returnString += list[list.Count - 1] + "\n";

        return returnString;
    }

    public static string BoolListToString(string title, List<bool> list) {
        string returnString = title + ": ";

        int index = 0;
        for (int i = 0; i < list.Count - 1; i++) {
            returnString += list[i].ToString() + ", ";
            index = i;
        }
        returnString += list[list.Count - 1] + "\n";

        return returnString;
    }

}
