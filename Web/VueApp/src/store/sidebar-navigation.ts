import { defineStore } from 'pinia'
import type { Navigation } from 'src/core/types'
import { ref } from 'vue'

export default defineStore('sidebar-navigation', () => {
  const defaultMenu = ref<Navigation[]>([
    {
      url: '/',
      icon: 'home',
      title: 'Home',
    },
  ])

  return { defaultMenu }
})
