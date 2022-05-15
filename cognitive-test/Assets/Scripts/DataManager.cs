using System.Collections.Generic;

public static class CSVManager {

    public class PersonData {
        public string Name { get; set; }
        public List<float> ReactionTimes { get; set; }
        public List<float> ConcentrationTimes { get; set; }

    }

    /// <summary>
    /// Writes the data stored in the PersonData class into a csv file.
    /// </summary>
    public static void LogData(PersonData personData) {
        string csv = "";

        // Add header
        csv += "Test Index,Reaction Time,Concentration Time\n";

        // Append data
        for (int i = 0; i < personData.ReactionTimes.Count; i++) { // Reaction times and concentration times list should be the same length.
            csv += i.ToString() + "," + personData.ReactionTimes[i].ToString() + "," + personData.ConcentrationTimes[i].ToString() + "\n";
        }

        // TODO: Write to text file
    }

}
