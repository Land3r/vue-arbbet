import { baseUrl } from './consts'
import axios from 'axios'

class Service {
    Run() {
        // Gets all sports
        getOffers(100)
    }
}

const getOffers = async (sportId) => {
    try {
        const res = await axios.get(`${baseUrl}1n2/offre?sport=${sportId}`);

        const offers = res.data;
    
        console.log(offers);
    
        return offers;
    } catch (e) {
    console.error(e);
  }
}

export default Service;