class DDRRam(override val size: Int, override val speed: Float) : Ram {
    override fun toString(): String {
        return "DDRRam(size=$size, speed=$speed)"
    }
}
