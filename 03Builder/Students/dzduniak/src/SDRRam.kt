class SDRRam(override val size: Int, override val speed: Float) : Ram {
    override fun toString(): String {
        return "SDRRam(size=$size, speed=$speed)"
    }
}
