// Table Enhancements JavaScript
// Handles search bar toggle, sorting arrows, and other table interactions

// Function to initialize table enhancements
function initializeTableEnhancements() {
    
    // Search bar toggle functionality
    function initSearchToggle() {
        const searchContainers = document.querySelectorAll('.search-container');
        
        searchContainers.forEach(container => {
            const toggleIcon = container.querySelector('.search-toggle-icon');
            const searchInput = container.querySelector('.search-input');
            
            if (toggleIcon && searchInput) {
                // Skip if already initialized
                if (toggleIcon.dataset.initialized) return;
                toggleIcon.dataset.initialized = 'true';
                
                // Initially hide the search input
                searchInput.classList.add('hidden');
                
                toggleIcon.addEventListener('click', function(e) {
                    e.preventDefault();
                    e.stopPropagation();
                    
                    if (searchInput.classList.contains('hidden')) {
                        // Show search input
                        searchInput.classList.remove('hidden');
                        searchInput.focus();
                    } else {
                        // Hide search input
                        searchInput.classList.add('hidden');
                        searchInput.value = '';
                        // Trigger any bound search event to clear results
                        searchInput.dispatchEvent(new Event('input'));
                    }
                });
                
                // Close search when clicking outside
                document.addEventListener('click', function(e) {
                    if (!container.contains(e.target) && !searchInput.classList.contains('hidden')) {
                        searchInput.classList.add('hidden');
                        searchInput.value = '';
                        searchInput.dispatchEvent(new Event('input'));
                    }
                });
                
                // Prevent search input from closing when clicking inside
                searchInput.addEventListener('click', function(e) {
                    e.stopPropagation();
                });
            }
        });
    }
    
    // Add sort arrows to table headers
    function initTableSorting() {
        const tables = document.querySelectorAll('.app-table, .datatable-table');
        
        tables.forEach(table => {
            const headers = table.querySelectorAll('thead th');
            
            headers.forEach((header, index) => {
                // Skip if already has sorting elements
                if (header.querySelector('.sort-arrows')) return;
                
                // Add sort arrows container
                const sortArrows = document.createElement('div');
                sortArrows.className = 'sort-arrows';
                sortArrows.innerHTML = `
                    <span class="sort-arrow-up">▲</span>
                    <span class="sort-arrow-down">▼</span>
                `;
                header.appendChild(sortArrows);
                
                // Add click handler for sorting
                header.addEventListener('click', function() {
                    // Remove existing sort classes from all headers
                    headers.forEach(h => {
                        h.classList.remove('sort-asc', 'sort-desc');
                    });
                    
                    // Determine new sort direction
                    let sortDir = 'asc';
                    if (header.dataset.sortDirection === 'asc') {
                        sortDir = 'desc';
                    }
                    
                    // Update header
                    header.dataset.sortDirection = sortDir;
                    header.classList.add('sort-' + sortDir);
                    
                    // Perform actual sorting
                    sortTable(table, index, sortDir);
                });
            });
        });
    }
    
    // Simple table sorting function
    function sortTable(table, columnIndex, direction) {
        const tbody = table.querySelector('tbody');
        if (!tbody) return;
        
        const rows = Array.from(tbody.querySelectorAll('tr'));
        
        rows.sort((a, b) => {
            const aText = a.cells[columnIndex]?.textContent?.trim() || '';
            const bText = b.cells[columnIndex]?.textContent?.trim() || '';
            
            // Try to parse as numbers first
            const aNum = parseFloat(aText.replace(/[^0-9.-]/g, ''));
            const bNum = parseFloat(bText.replace(/[^0-9.-]/g, ''));
            
            let comparison = 0;
            if (!isNaN(aNum) && !isNaN(bNum)) {
                // Numeric sort
                comparison = aNum - bNum;
            } else {
                // Text sort
                comparison = aText.localeCompare(bText);
            }
            
            return direction === 'asc' ? comparison : -comparison;
        });
        
        // Rebuild tbody with sorted rows
        rows.forEach(row => tbody.appendChild(row));
    }
    
    // Initialize all enhancements
    initSearchToggle();
    initTableSorting();
}

// Initialize when DOM is ready
window.addEventListener('DOMContentLoaded', initializeTableEnhancements);

// Initialize when Blazor finishes loading (for Blazor Server)
window.addEventListener('load', initializeTableEnhancements);

// For Blazor Server, also initialize after navigation
if (window.Blazor) {
    window.Blazor.addEventListener('enhancedload', initializeTableEnhancements);
} else {
    // Fallback: watch for when Blazor becomes available
    const checkBlazor = setInterval(() => {
        if (window.Blazor) {
            window.Blazor.addEventListener('enhancedload', initializeTableEnhancements);
            clearInterval(checkBlazor);
        }
    }, 100);
}

// Also run periodically to catch any dynamically loaded content
setInterval(initializeTableEnhancements, 2000);