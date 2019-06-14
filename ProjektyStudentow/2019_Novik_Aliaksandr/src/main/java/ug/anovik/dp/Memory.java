package ug.anovik.dp;

import java.io.Serializable;

public class Memory implements Cloneable, Serializable {

	private static final long serialVersionUID = 27L;
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

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + (memoryCard ? 1231 : 1237);
		result = prime * result + ram;
		result = prime * result + rom;
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Memory other = (Memory) obj;
		if (memoryCard != other.memoryCard)
			return false;
		if (ram != other.ram)
			return false;
		if (rom != other.rom)
			return false;
		return true;
	}

	
	
}
