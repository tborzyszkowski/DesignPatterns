<?php

interface Bookable
{
    public function booking();
}

class ConferenceRoom implements Bookable
{
    public function booking()
    {
        echo "Conference Room has been booked \n";
    }
}

class CompanyCar implements Bookable
{
    public function booking()
    {
        echo "Company Car has been booked\n";
    }
}

class BookingAdapter
{
    private $bookable;

    public function __construct(Bookable $bookable)
    {
        $this->bookable = $bookable;
    }

    public function booking()
    {
        echo "Method of class has been called by Booking Adapter \n";
        $this->bookable->booking();
    }
}

// test

$conferenceRoom = new ConferenceRoom();
$companyCar = new CompanyCar();

$bookingAdapter = new BookingAdapter($conferenceRoom);
$bookingAdapter->booking();

$bookingAdapter2 = new BookingAdapter($companyCar);
$bookingAdapter2->booking();
