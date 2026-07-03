package acsse.csc2a.bio.gui;

import java.io.File;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import acsse.csc2a.bio.effects.ChamberEngine;
import acsse.csc2a.bio.file.ChamberFileHandler;
import acsse.csc2a.bio.generator.E_BURST_SIZE;
import acsse.csc2a.bio.model.BioFlora;
import acsse.csc2a.bio.model.GrowthChamber;
import acsse.csc2a.bio.pattern.BioSporePool;
import acsse.csc2a.bio.threading.SporeBurstTask;
import javafx.animation.AnimationTimer;
import javafx.scene.control.Menu;
import javafx.scene.control.MenuBar;
import javafx.scene.control.MenuItem;
import javafx.scene.layout.Priority;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;

/**
 * A JavaFX VBox container that houses the ChamberDisplayCanvas and a MenuBar.
 * Provides File, Simulation, and Burst menus allowing the user to load a
 * Growth Chamber layout, control animation, and trigger spore burst events.
 *
 * @version P09
 */
public class ChamberDisplayBox extends VBox  {

    /** The currently loaded GrowthChamber. */
    private GrowthChamber chamber;

    /** The menu bar providing File, Simulation, and Burst controls. */
    private MenuBar menuBar;

    /** The canvas on which specimens and spores are rendered. */
    private ChamberDisplayCanvas chamberCanvas;

    /** The JavaFX AnimationTimer driving the animations. */
    private AnimationTimer timer;

    /** Tracks the nanosecond timestamp of the last frame. */
    private long lastFrameTime = 0;

    /** Accumulated simulation time in seconds. */
    private double simulationTime = 0.0;

    /** The spore simulation engine. */
    private ChamberEngine engine;

    /**
     * Constructs a ChamberDisplayBox with the specified canvas dimensions.
     *
     * @param width  Canvas width in pixels.
     * @param height Canvas height in pixels.
     */
    public ChamberDisplayBox(int width, int height) {
        chamberCanvas = new ChamberDisplayCanvas(width, height);

        // Initialise the engine with the canvas GraphicsContext
        engine = new ChamberEngine(chamberCanvas.getGraphicsContext2D());

        // Give the engine a spore pool to work with
        engine.setPool(new BioSporePool());

        createMenuBar();

        getChildren().add(menuBar);
        getChildren().add(chamberCanvas);
        VBox.setVgrow(chamberCanvas, Priority.ALWAYS);

        this.timer = new AnimationTimer() {
            @Override
            public void handle(long now) {
                if (lastFrameTime > 0) {
                    long deltaNanos     = now - lastFrameTime;
                    double deltaSeconds = deltaNanos / 1_000_000_000.0;
                    simulationTime     += deltaSeconds;
                }

                // Update and render specimens if a chamber is loaded
                if (chamber != null) {
                    for (BioFlora specimen : chamber.getSpecimens()) {
                        specimen.update(simulationTime);
                    }
                    chamberCanvas.updateAndRedraw(simulationTime);
                }

                // Always tick and render spores
                engine.tick();
                engine.renderAll();

                lastFrameTime = now;
            }
        };
    }

    /**
     * Constructs a ChamberDisplayBox with default dimensions.
     */
    public ChamberDisplayBox() {
        this(1000, 700);
    }
 // -------------------------------------------------------------------------
 // Private helpers
 // -------------------------------------------------------------------------

 /**
  * Starts the AnimationTimer.
  */
 private void startSimulation() {
     this.timer.start();
 }

 /**
  * Stops the AnimationTimer.
  */
 private void stopSimulation() {
     this.timer.stop();
 }

 /**
  * Triggers 10 SporeBurstTasks of the given size simultaneously
  * using an ExecutorService.
  *
  * @param size the burst size to trigger
  */
 private void triggerBurst(E_BURST_SIZE size) {
     // [15 marks] Fixed thread pool of 10 created to run tasks simultaneously
     ExecutorService service = Executors.newFixedThreadPool(10);
     // [15 marks] 10 SporeBurstTask instances submitted — one per thread
     for (int i = 0; i < 10; i++) {
         service.execute(new SporeBurstTask(engine, size));
     }
     // [15 marks] ExecutorService shut down after all tasks submitted
     service.shutdown();
 }

 /**
  * Builds and populates the MenuBar with File, Simulation, and Burst menus.
  */
 private void createMenuBar() {
     menuBar = new MenuBar();

     // --- File Menu ---
     Menu fileMenu = new Menu("File");
     MenuItem openItem = new MenuItem("Open Chamber Layout");
     openItem.setOnAction(e -> {
         FileChooser fc = new FileChooser();
         fc.setTitle("Choose Chamber Layout");
         fc.setInitialDirectory(new File("data/"));
         File file = fc.showOpenDialog(getScene().getWindow());
         if (file != null) {
             ChamberFileHandler handler = new ChamberFileHandler();
             chamber = handler.readLayout(file);
             setChamber(chamber);
         }
     });
     fileMenu.getItems().add(openItem);
     menuBar.getMenus().add(fileMenu);

     // --- Simulation Menu ---
     Menu simMenu = new Menu("Simulation");
     MenuItem startItem = new MenuItem("Start");
     startItem.setOnAction(e -> startSimulation());
     MenuItem stopItem = new MenuItem("Stop");
     stopItem.setOnAction(e -> stopSimulation());
     simMenu.getItems().addAll(startItem, stopItem);
     menuBar.getMenus().add(simMenu);

     // [3 marks] Burst menu added to existing MenuBar
     Menu burstMenu = new Menu("Burst");

     // [10 marks] MenuItem created for each E_BURST_SIZE value
     MenuItem smallItem  = new MenuItem("Small");
     MenuItem mediumItem = new MenuItem("Medium");
     MenuItem largeItem  = new MenuItem("Large");
     MenuItem megaItem   = new MenuItem("Mega");

     // [15 marks] Each MenuItem delegates to triggerBurst with the correct size
     //doesnt have to be a lambda function
     smallItem.setOnAction(e  -> triggerBurst(E_BURST_SIZE.SMALL));
     mediumItem.setOnAction(e -> triggerBurst(E_BURST_SIZE.MEDIUM));
     largeItem.setOnAction(e  -> triggerBurst(E_BURST_SIZE.LARGE));
     megaItem.setOnAction(e   -> triggerBurst(E_BURST_SIZE.MEGA));

     // [10 marks] All MenuItems added to the Burst menu
     burstMenu.getItems().addAll(smallItem, mediumItem, largeItem, megaItem);
     // [3 marks] Burst menu added to MenuBar
     menuBar.getMenus().add(burstMenu);
 }

 /**
  * Passes the loaded GrowthChamber to the canvas and resets simulation time.
  *
  * @param chamber The GrowthChamber to display.
  */
 private void setChamber(GrowthChamber chamber) {
     this.simulationTime = 0.0;
     this.lastFrameTime  = 0;
     chamberCanvas.setChamber(chamber);
 }

 /**
  * Shuts down the spore engine thread pool cleanly.
  * Called when the application window is closed.
  */
 public void shutdown() {
     if (engine != null) {
         engine.shutdown();
     }
 }
}
