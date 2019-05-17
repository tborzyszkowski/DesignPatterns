package ug.anovik.NovikAliaksandr.FluentBuilder;

public class Camera {
	private int num;
	private String mgpix;

	public Camera(int num, String mgpix) {
		this.num = num;
		this.mgpix = mgpix;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

	public String getMgpix() {
		return mgpix;
	}

	public void setMgpix(String mgpix) {
		this.mgpix = mgpix;
	}

	@Override
	public String toString() {
		return "Camera [num=" + num + ", mgpix=" + mgpix + "]";
	}

}
