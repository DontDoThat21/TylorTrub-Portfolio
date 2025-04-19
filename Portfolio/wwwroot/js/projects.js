// Project filtering and interaction functionality
document.addEventListener('DOMContentLoaded', function() {
    // Elements
    const languageFilter = document.getElementById('languageFilter');
    const projectCards = document.querySelectorAll('.project-card');
    const projectsContainer = document.getElementById('projectsContainer');
    const emptyState = document.getElementById('emptyState');
    const resetFilterButton = document.getElementById('resetFilter');

    // Function to filter projects
    function filterProjects() {
        const selectedLanguage = languageFilter.value;
        let visibleCount = 0;
        
        projectCards.forEach(card => {
            const cardLanguage = card.dataset.language;
            
            if (selectedLanguage === 'all' || cardLanguage === selectedLanguage) {
                card.classList.remove('d-none');
                visibleCount++;
            } else {
                card.classList.add('d-none');
            }
        });
        
        // Show/hide empty state
        if (visibleCount === 0) {
            projectsContainer.classList.add('d-none');
            emptyState.classList.remove('d-none');
        } else {
            projectsContainer.classList.remove('d-none');
            emptyState.classList.add('d-none');
        }
    }
    
    // Event listeners
    if (languageFilter) {
        languageFilter.addEventListener('change', filterProjects);
    }
    
    if (resetFilterButton) {
        resetFilterButton.addEventListener('click', function() {
            languageFilter.value = 'all';
            filterProjects();
        });
    }
    
    // Fix GitHub URLs if they're not properly formatted
    document.querySelectorAll('.project-card a[href]').forEach(link => {
        const url = link.getAttribute('href');
        if (url && url !== '#' && !url.startsWith('http')) {
            link.setAttribute('href', 'https://' + url);
        }
    });
});
