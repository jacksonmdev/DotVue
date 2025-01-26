<template>
  <q-list>
    <q-item-label header class="text-caption">{{ title }}</q-item-label>

    <q-item
      clickable
      tag="a"
      v-for="(item, index) in menu"
      :key="index"
      :to="item.url"
      exact
    >
      <q-item-section avatar>
        <q-icon :name="item.icon" v-if="item.icon" />
      </q-item-section>

      <q-item-section>
        <q-item-label>{{ item.title }}</q-item-label>
        <q-item-label caption v-if="item.caption">{{
          item.caption
        }}</q-item-label>
      </q-item-section>
    </q-item>
  </q-list>
</template>

<script setup lang="ts">
import type { Navigation } from 'src/core/types'

defineProps<{
  title?: string
  menu?: Navigation[]
}>()
</script>

<style scoped></style>
