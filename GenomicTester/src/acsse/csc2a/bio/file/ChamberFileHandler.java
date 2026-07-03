package acsse.csc2a.bio.file;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.ObjectInputStream;
import java.io.IOException;

import acsse.csc2a.bio.model.*;
import acsse.csc2a.bio.file.FloraFileReader;

/**
 * Handles reading and loading of growth chamber data from binary files.
 * <p>
 * This class reads a binary file containing a chamber name and specimen data,
 * then updates the specimens in the corresponding {@link GrowthChamber} layout.
 * </p>
 */
public class ChamberFileHandler {
	 /**
     * Reads a growth chamber layout and updates specimen attributes from a binary file.
     * <p>
     * The binary file is expected to contain:
     * <ol>
     *     <li>The name of the chamber as a UTF string.</li>
     *     <li>Pairs of specimen names (UTF strings) and double values representing updates.</li>
     * </ol>
     * The method uses the chamber name to load the corresponding text layout file via {@link FloraFileReader}.
     * It then updates each specimen in the chamber according to its type:
     * <ul>
     *     <li>{@link Flower} – updates petal hydration.</li>
     *     <li>{@link Mushroom} – updates glow intensity.</li>
     *     <li>{@link Vine} – updates sway intensity.</li>
     * </ul>
     *
     * @param binaryFile the binary file containing the chamber name and specimen updates
     * @return the {@link GrowthChamber} with updated specimens, or {@code null} if an error occurs
     */
    public GrowthChamber readLayout(File binaryFile) {

GrowthChamber chamber = null;

try (DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(binaryFile)))) {

    // (b) Read chamber name
    String chamberName = dis.readUTF();

    // Use chamber name to load correct file
    File ChamberFile = new File("data/" + chamberName + ".txt");

    FloraFileReader reader = new FloraFileReader();
    chamber = reader.readChamberFile(ChamberFile);

    // (c) Read specimen updates
    while (dis.available() > 0) {

        String name = dis.readUTF();
        double value = dis.readDouble();

        BioFlora specimen = chamber.getSpecimenByName(name);

        if (specimen != null) {

            // (d) instanceof + downcasting
            if (specimen instanceof Flower) {
                ((Flower) specimen).setPetalHydration(value);

            } else if (specimen instanceof Mushroom) {
                ((Mushroom) specimen).setGlowIntensity(value);

            } else if (specimen instanceof Vine) {
                ((Vine) specimen).setSwayIntensity(value);
            }
        }
    }

        } catch (IOException e) {
            e.printStackTrace();
        }

        return chamber;
    }
}