import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard, authSettled } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/runewords',
    name: 'Runewords',
    component: loadPage('RunewordsPage'),
    beforeEnter: authSettled
  },
  {
    path: '/runes',
    name: 'Runes',
    component: loadPage('RunesPage')
  },
  {
    path: '/myrunes',
    name: 'MyRunes',
    component: loadPage('MyRunesPage'),
    beforeEnter: authGuard
  },
  {
    path: '/items',
    name: 'Items',
    component: loadPage('ItemsPage')
  },
  {
    path: '/abilities',
    name: 'Abilities',
    component: loadPage('AbilitiesPage')
  },
  {
    path: '/hunts',
    name: 'Hunts',
    component: loadPage('HuntsPage')
  },
  {
    path: '/miscellaneous',
    name: 'Misc',
    component: loadPage('MiscPage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
