public class RentFacade {

    public boolean isRentPossible(Customer customer, Movie movie) {
        if (customer.getRentedMovies() >= 3) {
            return false;
        } else if (movie.isRented()) {
            return  false;
        } else if (movie.isDamaged()) {
            return false;
        }

        return true;
    }
}
