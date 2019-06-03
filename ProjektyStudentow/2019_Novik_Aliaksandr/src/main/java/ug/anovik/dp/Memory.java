package ug.anovik.dp;

public class Memory {
	
	private int rom;
	private int ram;
	private boolean memoryCard;
	
	public Memory(int rom, int ram, boolean memoryCard) {
		super();
		this.rom = rom;
		this.ram = ram;
		this.memoryCard = memoryCard;
	}

	public int getRom() {
		return rom;
	}

	public void setRom(int rom) {
		this.rom = rom;
	}

	public int getRam() {
		return ram;
	}

	public void setRam(int ram) {
		this.ram = ram;
	}

	public boolean isMemoryCard() {
		return memoryCard;
	}

	public void setMemoryCard(boolean memoryCard) {
		this.memoryCard = memoryCard;
	}

	@Override
	public String toString() {
		return "Memory [rom=" + rom + ", ram=" + ram + ", memoryCard=" + memoryCard + "]";
	}
	
	
}
