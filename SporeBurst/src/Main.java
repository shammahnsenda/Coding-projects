import acsse.csc2a.bio.gui.ChamberDisplayBox;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 * Entry point for the BFI Bio-Flora Screensaver application.
 * Launches the JavaFX application and sets up the primary stage.
 *
 * @author 
 * @version 
 */
public class Main extends Application {

    /** Canvas width in pixels. */
    private static final int WIDTH = 1000;

    /** Canvas height in pixels. */
    private static final int HEIGHT = 700;

    /**
     * The main entry point for the application.
     * Launches the JavaFX runtime.
     *
     * @param args Command-line arguments (not used).
     */
    public static void main(String[] args) {
        launch(args);
    }

    /**
     * Initialises the JavaFX Stage and Scene.
     * Registers a shutdown hook to cleanly terminate the spore engine
     * thread pool when the application window is closed.
     *
     * @param primaryStage The primary stage provided by the JavaFX runtime.
     */
    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("BFI Bio-Flora Screensaver");

        ChamberDisplayBox root = new ChamberDisplayBox();

        Scene scene = new Scene(root, WIDTH, HEIGHT);
        primaryStage.setScene(scene);

        // Shut down the spore engine thread pool cleanly on window close
        primaryStage.setOnCloseRequest(e -> root.shutdown());

        primaryStage.show();
    }
}