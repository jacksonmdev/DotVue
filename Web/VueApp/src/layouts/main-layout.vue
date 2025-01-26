<template>
  <q-layout view="lHh LpR lFf">
    <AppHeader @toggle-drawer="toggleDrawer" />
    <AppDrawer v-model="drawer" />
    <q-page-container>
      <q-page class="q-pa-lg">
        <PageTitle />
        <router-view />
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const drawer = ref<boolean>(false)
const toggleDrawer = () => (drawer.value = !drawer.value)
</script>

<style scoped></style>
