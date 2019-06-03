package ug.anovik.dp;

public class Camera {
	
	private double mp;
	private double fNumber;
	private PhotoType photoType;
	
	public Camera(double mp, double fNumber, PhotoType photoType) {
		super();
		this.mp = mp;
		this.fNumber = fNumber;
		this.photoType = photoType;
	}

	public double getMp() {
		return mp;
	}

	public void setMp(double mp) {
		this.mp = mp;
	}

	public double getfNumber() {
		return fNumber;
	}

	public void setfNumber(double fNumber) {
		this.fNumber = fNumber;
	}

	public PhotoType getPhotoType() {
		return photoType;
	}

	public void setPhotoType(PhotoType photoType) {
		this.photoType = photoType;
	}

	@Override
	public String toString() {
		return "Camera [mp=" + mp + ", fNumber=" + fNumber + ", photoType=" + photoType + "]";
	}
	
}
