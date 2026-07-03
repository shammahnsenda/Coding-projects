package acsse.csc2a.bio.model;

/**
 * Represents an object whose state can be updated over time.
 * Classes implementing this interface should define how the object
 * updates its internal state when the update method is called.
 */
public interface IUpdatable {
	 /**
     * Updates the state of the object based on the given time step.
     *
     * @param t the time step or elapsed time over which to update the object's state
     */
	public void update(double t);
}
