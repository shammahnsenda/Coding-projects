package acsse.csc2a.bio.threading;

import acsse.csc2a.bio.effects.ChamberEngine;
import acsse.csc2a.bio.generator.E_BURST_SIZE;

public class SporeBurstTask implements Runnable {

	ChamberEngine engine;
	E_BURST_SIZE size;

	
	/**
	 * @param engine
	 * @param size
	 */
	public SporeBurstTask(ChamberEngine engine, E_BURST_SIZE size) {
		this.engine = engine;
		this.size = size;
	}




	@Override
	public void run() {
		// TODO Auto-generated method stub
		switch(size) {
			
		case SMALL:
			engine.burstSmall();
		break;
		
		case MEDIUM:
			engine.burstMedium();
		break;
		
		case LARGE:
			engine.burstLarge();
		break;
		
		case MEGA:
			engine.burstMega();
		break;
		
		}
	}

}
