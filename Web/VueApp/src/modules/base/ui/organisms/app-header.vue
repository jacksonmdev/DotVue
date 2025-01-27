<template>
  <q-header>
    <q-toolbar id="app-toolbar">
      <q-btn dense flat icon="menu" @click="$emit('toggleDrawer')" />
      <q-toolbar-title> {{ $t('common.app.name') }} </q-toolbar-title>
      <q-separator></q-separator>
    </q-toolbar>
  </q-header>
</template>

<script lang="ts" setup></script>

<style scoped>
#app-toolbar {
  background: radial-gradient(ellipse at center, #05ab81, #0072c6);
  background-size: 200% 200%;
  animation: gradientAnimation 7s ease infinite;
}

@keyframes gradientAnimation {
  0% {
    background-size: 200% 200%;
  }
  50% {
    background-size: 150% 150%;
  }
  100% {
    background-size: 200% 200%;
  }
}
</style>
