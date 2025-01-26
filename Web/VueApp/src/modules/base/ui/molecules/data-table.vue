<template>
  <q-table
    :rows="data"
    :columns="columns"
    row-key="name"
    flat
    bordered
    :hide-header="!(data.length > 0)"
    :pagination="paginationOptions"
    :rows-per-page-options="[25, 50, 100]"
  >
  </q-table>
</template>

<script setup lang="ts">
defineProps({
  title: { type: String, default: () => 'Data Table' },
  columns: { type: Array<any>, default: () => [] },
  data: { type: Array<any>, default: () => [] },
})

const paginationOptions = {
  rowsPerPage: 25,
}
</script>

<style scoped></style>
