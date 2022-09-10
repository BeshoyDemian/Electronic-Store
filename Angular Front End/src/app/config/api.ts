import { environment } from 'src/environments/environment'

export const baseUrl = environment.production ?  'http://localhost:3000'  : 'http://localhost:3000/api' //:'https://api.LinkDev-Shop.com'
export const productsUrl = baseUrl + '/Products'
export const cartUrl = baseUrl + '/Carts'
export const wishlistUrl = baseUrl + '/Favorites'
